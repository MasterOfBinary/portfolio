//---------------------------------------------------------------------------
// engine.h
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include <windows.h>
#include <d3d10.h>
#include <d3dx10.h>

#include "exp.h"
#include "scene.h"
#include "timer.h"
#include "types.h"

#ifndef _ENGINE_H_
#define _ENGINE_H_

namespace pge
{
	class Camera;

	struct InitParams
	{
		UINT BufferCount;
		bool Windowed;
		UINT Width;
		UINT Height;
		PGE_ENGINE_FORMAT Format;
		UINT RefreshRate;
		bool CreateDepthStencil;
		bool RenderWireframe;
		bool NoCulling;
	};

	struct Viewport
	{
		int TopLeftX;
		int TopLeftY;
		UINT Width;
		UINT Height;
		float MinDepth;
		float MaxDepth;
	};

	struct ProjectionFov
	{
		float FovY;
		float Aspect;
		float NearZ;
		float FarZ;
	};

	class PGE_API Engine
	{
	public:
		Engine(HWND hWnd);
		PGE_RETURN Create(InitParams *Params);
		void Destroy();
		bool IsCreated();
		void SetVSync(bool VSync);
		void ResizeWindow();

		void SetFullScreen(bool FullScreen);
		bool IsFullScreen();

		void BeginScene();
		void DrawEntireScene(Scene *DrawScene);
		void EndSceneAndPresent();

		DWORD GetLastFrameTime();
		float GetFramesPerSecond();

		Viewport *CreateDefaultViewport();
		void SetViewport(Viewport *Viewport);

		ProjectionFov *CreateDefaultProjectionFov();
		void SetProjectionFov(ProjectionFov *Fov);

		ID3D10Device *GetD3D10Device();

		Camera *GetCurrentCamera();
		void SetCurrentCamera(Camera *NewCamera);

		Matrix *GetProjectionMatrix();

	protected:
		HRESULT SetupRenderTargetView();
		HRESULT SetupDepthStencilView(UINT Width, UINT Height);
		DXGI_SWAP_CHAIN_DESC GetSwapChainDesc();

		HWND m_hWnd;
		int m_VSync;
		DWORD m_LastFrameTime;
		Timer m_Timer;
		bool m_FullScreen;
		bool m_CreateDepthStencil;

		ID3D10Device *m_pd3dDevice;
		IDXGISwapChain *m_pSwapChain;
		ID3D10RenderTargetView *m_pRenderTargetView;
		ID3D10RasterizerState *m_pRasterState;
		ID3D10Texture2D *m_pDepthStencil;
		ID3D10DepthStencilView *m_pDepthStencilView;
		ID3D10DepthStencilState *m_pDepthStencilState;

		Camera *m_pCurrentCamera;
		Matrix *m_pProjectionMatrix;
	};
}

#endif // _ENGINE_H_
