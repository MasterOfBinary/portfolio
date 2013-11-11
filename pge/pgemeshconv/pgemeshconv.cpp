//---------------------------------------------------------------------------
// pgemeshconv.cpp
// Perspective GX Game Engine Mesh Converter
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include "stdafx.h"

#define Write(type, num) { type nt = num; ofile.write((char *)&nt, sizeof(type)); }
#define WriteShort(s) Write(short, s);
#define WriteInt(i) Write(int, i);
#define WriteUint(i) Write(unsigned int, i);
#define WriteFloat(f) Write(float, f);
#define WriteVector2(v) { WriteFloat((v).x); WriteFloat((v).y); }
#define WriteVector3(v) { WriteFloat((v).x); WriteFloat((v).y); WriteFloat((v).z); }

#define VERTEX_POSITION 0x0001
#define VERTEX_COLOR 0x0002
#define VERTEX_NORMAL 0x0004
#define VERTEX_TEXCOORDS 0x0008

const float Scale = 3.0f;

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch (message)
	{
	case WM_DESTROY:
		PostQuitMessage(0);
		return 0;
	}

	return DefWindowProc(hWnd, message, wParam, lParam);
}

int _tmain(int argc, _TCHAR *argv[])
{
	if (argc <= 2)
	{
		cout << "No input or output file defined!" << endl;
		return 0;
	}

	cout << "Working..." << endl;

	// Create a window
	WNDCLASSEX wcex;
	ZeroMemory(&wcex, sizeof(wcex));
	wcex.cbSize         = sizeof(WNDCLASSEX);
	wcex.style			= CS_CLASSDC;
	wcex.lpfnWndProc	= WndProc;
	wcex.hInstance		= GetModuleHandle(NULL);
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.lpszClassName	= L"pgemcclass";

	RegisterClassEx(&wcex);

	HWND hWnd = CreateWindow(L"pgemcclass", L"", WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, 0,
		CW_USEDEFAULT, 0, GetDesktopWindow(), NULL, GetModuleHandle(NULL), NULL);

	IDirect3D9 *pD3D;
	IDirect3DDevice9 *pd3dDevice;
	if ((pD3D = Direct3DCreate9(D3D_SDK_VERSION)) == NULL)
		return 0;

	// Setup Direct3D
	D3DPRESENT_PARAMETERS d3dpp; 
	ZeroMemory(&d3dpp, sizeof(d3dpp));
	d3dpp.Windowed = TRUE;
	d3dpp.SwapEffect = D3DSWAPEFFECT_DISCARD;
	d3dpp.BackBufferFormat = D3DFMT_UNKNOWN;

	if (FAILED(pD3D->CreateDevice(D3DADAPTER_DEFAULT, D3DDEVTYPE_HAL, hWnd,
		D3DCREATE_SOFTWARE_VERTEXPROCESSING,
		&d3dpp, &pd3dDevice)))
		return 0;

	// Load the mesh
	LPD3DXMESH pMesh;
	if (FAILED(D3DXLoadMeshFromX(argv[1], D3DXMESH_32BIT | D3DXMESH_SYSTEMMEM, pd3dDevice,
		NULL, NULL, NULL, NULL, &pMesh)))
		return 0;

	// Open the output file
	ofstream ofile;
	ofile.open(argv[2], ios_base::out | ios_base::trunc | ios_base::binary);

	// The file header:
	// PGMxvvvv
	// Where
	//  x = The file version (currently 1)
	//  v = Offset to the vertex data

	char data[16];
	data[0] = 'P';
	data[1] = 'G';
	data[2] = 'M';
	data[3] = 1; // File version

	// Write the header
	ofile.write(data, 4);
	
	// Offset to vertex data (currently 0)
	WriteInt(0);

	// The vertex list:
	// nnnnssccvvvv...iiii
	// Where
	//  n = The number of vertices
	//  s = The size of each vertex
	//  c = The vertex components
	//  v = The list of vertices
	//  i = Offset to index data

	DWORD FVF = pMesh->GetFVF();

	int num = pMesh->GetNumVertices();

	// Write the number of vertices
	WriteInt(num);

	// Get the components
	short components = VERTEX_POSITION;
	if (FVF & D3DFVF_NORMAL)
		components |= VERTEX_NORMAL;
	if (FVF & D3DFVF_TEX1)
		components |= VERTEX_TEXCOORDS;

	// Get the size of each vertex
	short vertsize = sizeof(D3DXVECTOR3);
	if (components & VERTEX_NORMAL)
		vertsize += sizeof(D3DXVECTOR3); // Normal
	if (components & VERTEX_TEXCOORDS)
		vertsize += sizeof(D3DXVECTOR2); // Texture coordinate

	WriteShort(vertsize);
	WriteShort(components);

	// Get the vertex buffer
	D3DXVECTOR3 *vertices;
	DWORD BytesPerVertex = pMesh->GetNumBytesPerVertex();
	pMesh->LockVertexBuffer(D3DLOCK_READONLY, (void **)&vertices);

	// Write the vertices
	for (int x = 0; x < num; x++)
	{
		D3DXVECTOR3 *vertex = (D3DXVECTOR3 *)((byte *)vertices + x * BytesPerVertex);
		vertex->x *= Scale;
		vertex->y *= Scale;
		vertex->z *= Scale;
		WriteVector3(*vertex);

		int index = 1;

		if (components & VERTEX_NORMAL)
			WriteVector3(vertex[index++]);
		if (components & VERTEX_TEXCOORDS)
			WriteVector2((D3DXVECTOR2)vertex[index++]);
	}

	pMesh->UnlockVertexBuffer();

	// Write the offset to the index data (currently 0)
	WriteInt(0);

	// The index list:
	// nnnnssiiii...
	// Where
	//  n = The number of indices
	//  s = The size of each index
	//  i = The list of indices

	// Write the number of indices
	num = pMesh->GetNumFaces() * 3;
	WriteInt(num);

	// Write the size of each index
	WriteShort(4);

	UINT *indices;
	pMesh->LockIndexBuffer(D3DLOCK_READONLY, (void **)&indices);

	// Write the indices
	for (int x = 0; x < num; x++)
		WriteUint(indices[x]);

	pMesh->UnlockIndexBuffer();

	ofile.close();

	// Delete the mesh object
	if (pMesh)
		pMesh->Release();
	if (pd3dDevice)
		pd3dDevice->Release();
	if (pD3D)
		pD3D->Release();

	return 0;
}
