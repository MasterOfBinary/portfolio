//---------------------------------------------------------------------------
// engine.cpp
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include "stdafx.h"
#include "pge.h"
#include "private.h"

using namespace pge;

Engine::Engine(HWND hWnd)
{
	m_hWnd = hWnd;
	m_VSync = 0; // Turn off vsync by default
	m_LastFrameTime = 0;
	m_FullScreen = false;
	m_CreateDepthStencil = false;

	m_pd3dDevice = NULL;
	m_pSwapChain = NULL;
	m_pRenderTargetView = NULL;
	m_pRasterState = NULL;
	m_pDepthStencil = NULL;
	m_pDepthStencilView = NULL;
	m_pDepthStencilState = NULL;

	m_pCurrentCamera = NULL;

	m_pProjectionMatrix = NULL;
}

PGE_RETURN Engine::Create(InitParams *Params)
{
	HRESULT hr = S_OK;

	if (m_hWnd == NULL)
		return PGE_RETURN_INVALID_WINDOW;

	// Set the swap chain options
	DXGI_SWAP_CHAIN_DESC sd;
	ClearStruct(sd);
	sd.OutputWindow = m_hWnd;
	sd.BufferCount = (Params->BufferCount == 0 ? 2 : Params->BufferCount); // Default 2 buffers
	sd.BufferDesc.Format = (DXGI_FORMAT)(Params->Format == 0 ? PGE_ENGINE_FORMAT_32_R8G8B8A8 : Params->Format); // Default R8G8B8A8
	sd.BufferDesc.Width = (Params->Width == 0 ? 640 : Params->Width); // Default 640
	sd.BufferDesc.Height = (Params->Height == 0 ? 480 : Params->Height); // Default 480
	sd.BufferDesc.RefreshRate.Numerator = (Params->RefreshRate == 0 ? 60 : Params->RefreshRate); // Default 60/1
	sd.BufferDesc.RefreshRate.Denominator = 1; // Default 60/1
    sd.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
	sd.SampleDesc.Count = 1; // todo Allow multisampling?
	sd.SampleDesc.Quality = 0;
	sd.Windowed = Params->Windowed;

	// Create D3D10 device and swap chain
	hr = D3D10CreateDeviceAndSwapChain(NULL, D3D10_DRIVER_TYPE_HARDWARE, NULL, 0, 
		D3D10_SDK_VERSION, &sd, &m_pSwapChain, &m_pd3dDevice);

	SafeCheckResult(hr, PGE_RETURN_ERROR_CREATING_DEVICE);

	// Create a rasterizer state
    D3D10_RASTERIZER_DESC rasterizerState;
	rasterizerState.FillMode = (Params->RenderWireframe ? D3D10_FILL_WIREFRAME : D3D10_FILL_SOLID);
	rasterizerState.CullMode = (Params->NoCulling ? D3D10_CULL_NONE : D3D10_CULL_BACK);
    rasterizerState.FrontCounterClockwise = false;
    rasterizerState.DepthBias = false;
    rasterizerState.DepthBiasClamp = 0;
    rasterizerState.SlopeScaledDepthBias = 0;
    rasterizerState.DepthClipEnable = true;
    rasterizerState.ScissorEnable = false;
    rasterizerState.MultisampleEnable = true;
    rasterizerState.AntialiasedLineEnable = false;
    m_pd3dDevice->CreateRasterizerState(&rasterizerState, &m_pRasterState);

	m_CreateDepthStencil = Params->CreateDepthStencil;

	if (m_CreateDepthStencil)
	{
		D3D10_DEPTH_STENCIL_DESC dsDesc;

		// Depth test parameters
		dsDesc.DepthEnable = true;
		dsDesc.DepthWriteMask = D3D10_DEPTH_WRITE_MASK_ALL;
		dsDesc.DepthFunc = D3D10_COMPARISON_LESS;

		// Stencil test parameters
		dsDesc.StencilEnable = false;

		// Create depth stencil state
		hr = m_pd3dDevice->CreateDepthStencilState(&dsDesc, &m_pDepthStencilState);
		SafeCheckResult(hr, PGE_RETURN_ERROR_CREATING_DEPTH_STENCIL);

		hr = SetupDepthStencilView(sd.BufferDesc.Width, sd.BufferDesc.Height);
		SafeCheckResult(hr, PGE_RETURN_ERROR_CREATING_DEPTH_STENCIL);
	}

	// Set up the render target view
	ResizeWindow();

	return PGE_RETURN_NOERROR;
}

bool Engine::IsCreated()
{
	return (m_pd3dDevice != NULL);
}

void Engine::Destroy()
{
	m_Timer.EndTimer();

	SafeDelete(m_pProjectionMatrix);

	if (m_pd3dDevice)
		m_pd3dDevice->ClearState();

	SafeRelease(m_pDepthStencil);
	SafeRelease(m_pDepthStencilState);
	SafeRelease(m_pDepthStencilView);
	SafeRelease(m_pRasterState);
	SafeRelease(m_pRenderTargetView);
	if (m_pSwapChain)
		m_pSwapChain->SetFullscreenState(FALSE, NULL);
	SafeRelease(m_pSwapChain);

	if (m_pd3dDevice)
	{
		UINT references = m_pd3dDevice->Release();
		m_pd3dDevice = NULL;
#if (defined(DEBUG) || defined(_DEBUG))
		if (references)
			MessageBox(m_hWnd, L"The reference count is above 0. Something hasn't been released", L"Perspective GX Game Engine", MB_ICONWARNING);
#endif
	}
	
	delete this;
}

void Engine::SetVSync(bool VSync)
{
	m_VSync = (VSync ? 1 : 0);
}

void Engine::SetFullScreen(bool FullScreen)
{
	if (FullScreen == m_FullScreen)
		return;

	if (SUCCEEDED(m_pSwapChain->SetFullscreenState(FullScreen, NULL)))
	{
		m_FullScreen = !m_FullScreen;
		ResizeWindow();
	}
}

bool Engine::IsFullScreen()
{
	return m_FullScreen;
}

void Engine::ResizeWindow()
{
	// Release the render target
	SafeRelease(m_pRenderTargetView);

	// Get the client area of the window
	RECT rect;
	GetClientRect(m_hWnd, &rect);

	DXGI_SWAP_CHAIN_DESC desc = GetSwapChainDesc();

	int width = rect.right - rect.left;
	int height = rect.bottom - rect.top;

	HRESULT hr = m_pSwapChain->ResizeBuffers(desc.BufferCount, width, height, desc.BufferDesc.Format, 0);
	if (FAILED(hr))
		return;

	if (m_CreateDepthStencil)
		SetupDepthStencilView(width, height);

	SetupRenderTargetView();

	// Resize the render target
	DXGI_MODE_DESC mode;
	ClearStruct(mode);
	mode.Width = width;
	mode.Height = height;
	mode.Format = desc.BufferDesc.Format;
	mode.RefreshRate = desc.BufferDesc.RefreshRate;
	hr = m_pSwapChain->ResizeTarget(&mode);
	if (FAILED(hr))
		return;
}

void Engine::BeginScene()
{
	if (m_Timer.GetTimeElapsed() == 0)
		m_Timer.StartTimer();

	// Clear the back buffer
	float Color[4] = { 0.0f, 0.0f, 0.0f, 1.0f };
	m_pd3dDevice->ClearRenderTargetView(m_pRenderTargetView, Color);

	// Clear the depth stencil view
	if (m_CreateDepthStencil)
		m_pd3dDevice->ClearDepthStencilView(m_pDepthStencilView, D3D10_CLEAR_DEPTH | D3D10_CLEAR_STENCIL, 1.0, 0);

	// Bind raster state
	m_pd3dDevice->RSSetState(m_pRasterState);

	// Bind depth stencil state
	if (m_CreateDepthStencil)
		m_pd3dDevice->OMSetDepthStencilState(m_pDepthStencilState, 0);
}

void Engine::DrawEntireScene(Scene *DrawScene)
{
	DrawScene->DrawObjects();
}

void Engine::EndSceneAndPresent()
{
	m_LastFrameTime = m_Timer.GetTimeElapsed();

	m_pSwapChain->Present(m_VSync, 0);

	m_Timer.ResetTimer();
}

DWORD Engine::GetLastFrameTime()
{
	return m_LastFrameTime;
}

float Engine::GetFramesPerSecond()
{
	return 1000.0f / m_LastFrameTime;
}

Viewport *Engine::CreateDefaultViewport()
{
	RECT rect;
	GetClientRect(m_hWnd, &rect);

	// Create a viewport that starts at 0,0 and goes to Width,Height
	Viewport *v = new Viewport();
	ZeroMemory(v, sizeof(Viewport));
	v->Width = rect.right;
	v->Height = rect.bottom;
	v->MinDepth = 0.0f;
	v->MaxDepth = 1.0f;
	return v;
}

void Engine::SetViewport(Viewport *Viewport)
{
	D3D10_VIEWPORT v;
	ClearStruct(v);
	v.TopLeftX = Viewport->TopLeftX;
	v.TopLeftY = Viewport->TopLeftY;
	v.Width = Viewport->Width;
	v.Height = Viewport->Height;
	v.MinDepth = Viewport->MinDepth;
	v.MaxDepth = Viewport->MaxDepth;
	m_pd3dDevice->RSSetViewports(1, &v);
}

ProjectionFov *Engine::CreateDefaultProjectionFov()
{
	DXGI_SWAP_CHAIN_DESC sd = GetSwapChainDesc();
	float Aspect = (float)sd.BufferDesc.Width / (float)sd.BufferDesc.Height;

	ProjectionFov *p = new ProjectionFov();
	p->Aspect = Aspect;
	p->FovY = PiDiv4;
	p->NearZ = 0.1f;
	p->FarZ = 2000.0f;

	return p;
}

void Engine::SetProjectionFov(ProjectionFov *Fov)
{
	SafeDelete(m_pProjectionMatrix);
	m_pProjectionMatrix = new Matrix();

	D3DXMatrixPerspectiveFovLH(m_pProjectionMatrix, Fov->FovY, Fov->Aspect, Fov->NearZ, Fov->FarZ);
}

ID3D10Device *Engine::GetD3D10Device()
{
	return m_pd3dDevice;
}

Camera *Engine::GetCurrentCamera()
{
	return m_pCurrentCamera;
}

void Engine::SetCurrentCamera(Camera *NewCamera)
{
	if (NewCamera != NULL)
		m_pCurrentCamera = NewCamera;
}

Matrix *Engine::GetProjectionMatrix()
{
	return m_pProjectionMatrix;
}

HRESULT Engine::SetupRenderTargetView()
{
	HRESULT hr = S_OK;

	// Create a render target view
	ID3D10Texture2D *pBackBuffer;
	hr = m_pSwapChain->GetBuffer(0, __uuidof(ID3D10Texture2D), (LPVOID *)&pBackBuffer);
	SafeCheckResult(hr, hr);

	hr = m_pd3dDevice->CreateRenderTargetView(pBackBuffer, NULL, &m_pRenderTargetView);
	pBackBuffer->Release();
	SafeCheckResult(hr, hr);

	// Bind the render target and depth stencil view
	m_pd3dDevice->OMSetRenderTargets(1, &m_pRenderTargetView, m_pDepthStencilView);

	return hr;
}

HRESULT Engine::SetupDepthStencilView(UINT Width, UINT Height)
{
	SafeRelease(m_pDepthStencil);
	SafeRelease(m_pDepthStencilState);
	SafeRelease(m_pDepthStencilView);

	HRESULT hr = S_OK;

	DXGI_FORMAT format = DXGI_FORMAT_D24_UNORM_S8_UINT;

	// Create depth stencil buffer
	D3D10_TEXTURE2D_DESC descDepth;
	descDepth.Width = Width;
	descDepth.Height = Height;
	descDepth.MipLevels = 1;
	descDepth.ArraySize = 1;
	descDepth.Format = format;
	descDepth.SampleDesc.Count = 1;
	descDepth.SampleDesc.Quality = 0;
	descDepth.Usage = D3D10_USAGE_DEFAULT;
	descDepth.BindFlags = D3D10_BIND_DEPTH_STENCIL;
	descDepth.CPUAccessFlags = 0;
	descDepth.MiscFlags = 0;
	hr = m_pd3dDevice->CreateTexture2D(&descDepth, NULL, &m_pDepthStencil);
	SafeCheckResult(hr, hr);

	// Create the depth stencil view
	D3D10_DEPTH_STENCIL_VIEW_DESC descDSV;
	descDSV.Format = format;
	descDSV.ViewDimension = D3D10_DSV_DIMENSION_TEXTURE2D;
	descDSV.Texture2D.MipSlice = 0;

	hr = m_pd3dDevice->CreateDepthStencilView(m_pDepthStencil, &descDSV, &m_pDepthStencilView);
	SafeCheckResult(hr, hr);

	return hr;
}

DXGI_SWAP_CHAIN_DESC Engine::GetSwapChainDesc()
{
	DXGI_SWAP_CHAIN_DESC sd;
	m_pSwapChain->GetDesc(&sd);
	return sd;
}
