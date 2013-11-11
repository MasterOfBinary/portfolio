//---------------------------------------------------------------------------
// terrain.cpp
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include "stdafx.h"
#include "pge.h"
#include "private.h"

using namespace pge;
using namespace pge::SceneObjects;

struct pge::SceneObjects::TerrainVertex
{
	D3DXVECTOR3 Pos;        // Position
	D3DXVECTOR3 Norm;       // Normal
	D3DXVECTOR2 Tex;        // Texture coordinates
	D3DXVECTOR4 TexWeights; // Texture weights
};

TerrainParams *TerrainLoader::LoadFromBitmap(String FileName)
{
	Bitmap bitmap(FileName);

	UINT w = bitmap.GetWidth();
	UINT h = bitmap.GetHeight();

	float *heightmap = new float[w * h];

	for (UINT x = 0; x < bitmap.GetWidth(); x++)
	{
		for (UINT y = 0; y < bitmap.GetHeight(); y++)
		{
			// Set the height, inverting Z because we are using left-handed coordinates
			heightmap[x + (h - y - 1) * w] = (float)(byte)(bitmap.GetPixel(x, y)[0]);
		}
	}

	TerrainParams *p = new TerrainParams();
	ZeroMemory(p, sizeof(TerrainParams));
	p->HeightData = heightmap;
	p->Width = w;
	p->Height = h;

	return p;
}

Terrain::Terrain(TerrainParams *Params)
{
	m_pEffect = NULL;
	m_pVertexLayout = NULL;
	m_pVertexBuffer = NULL;
	m_pIndexBuffer = NULL;
	m_pTechnique = NULL;
	m_pTextures = NULL;

	m_pWorldVariable = NULL;
	m_pViewVariable = NULL;
	m_pProjectionVariable = NULL;
	m_pTex1Variable = NULL;
	m_pTex2Variable = NULL;
	m_pTex3Variable = NULL;
	m_pTex4Variable = NULL;

	m_TerrainParams = new TerrainParams();
	*m_TerrainParams = *Params;
	m_Vertices = NULL;
	m_IndexSize = 0;
}

bool Terrain::Create(Engine *ParentEngine)
{
	if (!SceneObject::Create(ParentEngine))
		return false;

	HRESULT hr = S_OK;

	ID3D10Device *pd3dDevice = ParentEngine->GetD3D10Device();

	// Create the effect
	hr = D3DX10CreateEffectFromFile(L"terrain.fx", NULL, NULL, "fx_4_0",
		D3D10_SHADER_ENABLE_STRICTNESS, 0, pd3dDevice, NULL, NULL, &m_pEffect, NULL, NULL);
	if (FAILED(hr))
		return false;

    // Obtain the technique
	m_pTechnique = m_pEffect->GetTechniqueByName("Render");

	// Obtain the variables
    m_pWorldVariable = m_pEffect->GetVariableByName("World")->AsMatrix();
    m_pViewVariable = m_pEffect->GetVariableByName("View")->AsMatrix();
    m_pProjectionVariable = m_pEffect->GetVariableByName("Projection")->AsMatrix();
	m_pTex1Variable = m_pEffect->GetVariableByName("tx1")->AsShaderResource();
	m_pTex2Variable = m_pEffect->GetVariableByName("tx2")->AsShaderResource();
	m_pTex3Variable = m_pEffect->GetVariableByName("tx3")->AsShaderResource();
	m_pTex4Variable = m_pEffect->GetVariableByName("tx4")->AsShaderResource();

	// Define the input layout
	D3D10_INPUT_ELEMENT_DESC layout[] =
	{
		{ "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 0, D3D10_INPUT_PER_VERTEX_DATA, 0 },
		{ "NORMAL", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 12, D3D10_INPUT_PER_VERTEX_DATA, 0 },
		{ "TEXCOORD", 0, DXGI_FORMAT_R32G32_FLOAT, 0, 24, D3D10_INPUT_PER_VERTEX_DATA, 0 },
		{ "TEXCOORD", 1, DXGI_FORMAT_R32G32B32A32_FLOAT, 0, 32, D3D10_INPUT_PER_VERTEX_DATA, 0 },
	};
	UINT numElements = sizeof(layout) / sizeof(layout[0]);

	// Load texture
	bool UseTexture = true;
	m_NumTextures = m_TerrainParams->NumTextures;

	if ((m_TerrainParams->NumTextures > 0) &&
		((m_TerrainParams->TextureCoords.X != 0) || (m_TerrainParams->TextureCoords.Y != 0)))
	{
		m_pTextures = new ID3D10ShaderResourceView *[m_NumTextures];
		
		for (int x = 0; x < m_NumTextures; x++)
		{
			hr = D3DX10CreateShaderResourceViewFromFileA(pd3dDevice, m_TerrainParams->TexturePaths[x].c_str(),
				NULL, NULL, &m_pTextures[x], NULL);

			if (FAILED(hr))
				UseTexture = false;
		}
	}
	else
		UseTexture = false;

	if (UseTexture)
	{
		if (m_pTextures[0])
			m_pTex1Variable->SetResource(m_pTextures[0]);
		if (m_pTextures[1])
			m_pTex2Variable->SetResource(m_pTextures[1]);
		if (m_pTextures[2])
			m_pTex3Variable->SetResource(m_pTextures[2]);
		if (m_pTextures[3])
			m_pTex4Variable->SetResource(m_pTextures[3]);
	}

	// Create the input layout
	D3D10_PASS_DESC PassDesc;
	m_pTechnique->GetPassByIndex(0)->GetDesc(&PassDesc);
	hr = pd3dDevice->CreateInputLayout(layout, numElements, PassDesc.pIAInputSignature, 
		PassDesc.IAInputSignatureSize, &m_pVertexLayout);
	if (FAILED(hr))
		return false;

	// Create vertices
	TerrainVertex *vertices = new TerrainVertex[m_TerrainParams->Width * m_TerrainParams->Height];

	int WidthDiv2 = m_TerrainParams->Width / 2;
	int HeightDiv2 = m_TerrainParams->Height / 2;

	if (m_TerrainParams->HScale < 0.00001)
		m_TerrainParams->HScale = 1.0;
	if (m_TerrainParams->VScale < 0.00001)
		m_TerrainParams->VScale = 1.0;

	for (int x = 0; x < m_TerrainParams->Width; x++)
	{
		float TexCoordX = m_TerrainParams->TextureCoords.X * (float)x / (float)m_TerrainParams->Width;
		for (int y = 0; y < m_TerrainParams->Height; y++)
		{
			int index = x + y * m_TerrainParams->Width;
			vertices[index].Pos = D3DXVECTOR3((float)(x - WidthDiv2) * m_TerrainParams->HScale,
				m_TerrainParams->HeightData[index] * m_TerrainParams->VScale,
				(float)(y - HeightDiv2) * m_TerrainParams->HScale);
			vertices[index].Norm = D3DXVECTOR3(0, 1, 0);

			if (UseTexture)
			{
				vertices[index].Tex = D3DXVECTOR2(TexCoordX,
					m_TerrainParams->TextureCoords.Y * (float)y / (float)m_TerrainParams->Height);

				// Set multitexturing
				vertices[index].TexWeights.x = m_TerrainParams->TextureData[index].X;
				vertices[index].TexWeights.y = m_TerrainParams->TextureData[index].Y;
				vertices[index].TexWeights.z = m_TerrainParams->TextureData[index].Z;
				vertices[index].TexWeights.w = m_TerrainParams->TextureData[index].W;
			}
		}
	}

	m_Bounds.X = (float)(-WidthDiv2 * m_TerrainParams->HScale);
	m_Bounds.Y = (float)(-HeightDiv2 * m_TerrainParams->HScale);
	m_Bounds.W = -m_Bounds.X * 2;
	m_Bounds.H = -m_Bounds.Y * 2;

	m_Size.X = (float)m_TerrainParams->Width;
	m_Size.Y = (float)m_TerrainParams->Height;

	// Smooth the terrain
	for (int run = 0; run < m_TerrainParams->NumSmoothingPasses; run++)
	{
		for (int x = 2; x < m_Size.X - 2; x++)
		{
			for (int y = 0; y < m_Size.Y; y++)
			{
				int index = x + y * (int)m_Size.X;
				vertices[index].Pos.y =
					(vertices[index - 2].Pos.y + vertices[index - 1].Pos.y +
					vertices[index + 1].Pos.y + vertices[index + 2].Pos.y) / 4.0f;
			}
		}
	}

	for (int run = 0; run < m_TerrainParams->NumSmoothingPasses; run++)
	{
		for (int index = m_Size.X; index < (m_Size.X * (m_Size.Y - 1)); index++)
		{
			vertices[index].Pos.y =
				(vertices[index - (int)m_Size.X].Pos.y +
				vertices[index + (int)m_Size.X].Pos.y) / 2.0f;
		}
	}

	// Now calculate the normals
	for (int x = 1; x < m_TerrainParams->Width - 1; x++)
	{
		for (int y = 1; y < m_TerrainParams->Height - 1; y++)
		{
			D3DXVECTOR3 normX = D3DXVECTOR3(
				(vertices[x - 1 + y * m_TerrainParams->Width].Pos.y -
				vertices[x + 1 + y * m_TerrainParams->Width].Pos.y) / 2, 1, 0);
			D3DXVECTOR3 normZ = D3DXVECTOR3(
				0, 1, (vertices[x + (y - 1) * m_TerrainParams->Width].Pos.y -
				vertices[x + (y + 1) * m_TerrainParams->Width].Pos.y) / 2);
			D3DXVECTOR3 norm = normX + normZ;
			D3DXVec3Normalize(&vertices[x + y * m_TerrainParams->Width].Norm, &norm);
		}
	}

	m_Vertices = vertices;

	// Create vertex buffer
	D3D10_BUFFER_DESC bd;
	bd.Usage = D3D10_USAGE_DEFAULT;
	bd.ByteWidth = sizeof(TerrainVertex) * m_TerrainParams->Width * m_TerrainParams->Height;
	bd.BindFlags = D3D10_BIND_VERTEX_BUFFER;
	bd.CPUAccessFlags = 0;
	bd.MiscFlags = 0;

	D3D10_SUBRESOURCE_DATA InitData;
	InitData.pSysMem = vertices;
	hr = pd3dDevice->CreateBuffer(&bd, &InitData, &m_pVertexBuffer);
	if (FAILED(hr))
		return false;

	// Create indices
	int RealWidth = m_TerrainParams->Width - 1;
	int RealHeight = m_TerrainParams->Height - 1;
	m_IndexSize = RealWidth * RealHeight * 6;
    UINT *indices = new UINT[m_IndexSize];

	for (int x = 0; x < RealWidth; x++)
	{
		for (int y = 0; y < RealHeight; y++)
		{
			int index = (x + y * RealWidth) * 6;
			int x1 = x + 1;
			int y1 = y + 1;

			// Triangle #1
			indices[index] = x1 + y1 * m_TerrainParams->Width;
			indices[index + 1] = x1 + y * m_TerrainParams->Width;
			indices[index + 2] = x + y * m_TerrainParams->Width;

			// Triangle #2
			indices[index + 3] = x1 + y1 * m_TerrainParams->Width;
			indices[index + 4] = x + y * m_TerrainParams->Width;
			indices[index + 5] = x + y1 * m_TerrainParams->Width;
		}
	}

	// Create index buffer
	D3D10_BUFFER_DESC bufferDesc;
	bufferDesc.Usage           = D3D10_USAGE_DEFAULT;
	bufferDesc.ByteWidth       = sizeof(UINT) * m_IndexSize;
	bufferDesc.BindFlags       = D3D10_BIND_INDEX_BUFFER;
	bufferDesc.CPUAccessFlags  = 0;
	bufferDesc.MiscFlags       = 0;

	D3D10_SUBRESOURCE_DATA IndexData;
	IndexData.pSysMem = indices;
	IndexData.SysMemPitch = 0;
	IndexData.SysMemSlicePitch = 0;
	hr = pd3dDevice->CreateBuffer(&bufferDesc, &IndexData, &m_pIndexBuffer);
	if (FAILED(hr))
		return false;

	return true;
}

void Terrain::DrawObject()
{
	HRESULT hr = S_OK;

	ID3D10Device *pd3dDevice = m_pEngine->GetD3D10Device();

	// Set the input layout
	pd3dDevice->IASetInputLayout(m_pVertexLayout);

	// Set vertex buffer
	UINT stride = sizeof(TerrainVertex);
	UINT offset = 0;
	pd3dDevice->IASetVertexBuffers(0, 1, &m_pVertexBuffer, &stride, &offset);

	// Set index buffer
	pd3dDevice->IASetIndexBuffer(m_pIndexBuffer, DXGI_FORMAT_R32_UINT, 0);

	// Set primitive topology
	pd3dDevice->IASetPrimitiveTopology(D3D10_PRIMITIVE_TOPOLOGY_TRIANGLELIST);

	// Set our matrices
	m_pWorldVariable->SetMatrix((float *)m_WorldMatrix);
	m_pViewVariable->SetMatrix((float *)m_pEngine->GetCurrentCamera()->GetViewMatrix());
	m_pProjectionVariable->SetMatrix((float *)m_pEngine->GetProjectionMatrix());

	// Render the terrain
	D3D10_TECHNIQUE_DESC techDesc;
	m_pTechnique->GetDesc(&techDesc);
	for (UINT p = 0; p < techDesc.Passes; ++p)
	{
		m_pTechnique->GetPassByIndex(p)->Apply(0);
		pd3dDevice->DrawIndexed(m_IndexSize, 0, 0);
	}
}

void Terrain::Destroy()
{
	m_Bounds = Rect();

	if (m_pTextures)
	{
		for (int x = 0; x < m_NumTextures; x++)
			SafeRelease(m_pTextures[x]);
	}
	SafeRelease(m_pIndexBuffer);
	SafeRelease(m_pVertexBuffer);
	SafeRelease(m_pVertexLayout);
    SafeRelease(m_pEffect);

	// SceneObject::Destroy() must be called last
	SceneObject::Destroy();
}

Rect Terrain::GetBounds()
{
	return m_Bounds;
}

PointInfo Terrain::GetTerrainPointInfo(float WorldX, float WorldZ)
{
	if (WorldX < m_Bounds.X)
		WorldX = m_Bounds.X;
	else if (WorldX > m_Bounds.X + m_Bounds.W)
		WorldX = m_Bounds.X + m_Bounds.W;

	if (WorldZ < m_Bounds.Y)
		WorldZ = m_Bounds.Y;
	else if (WorldZ > m_Bounds.Y + m_Bounds.H)
		WorldZ = m_Bounds.Y + m_Bounds.H; 

	PointInfo info;
	info.Position = Vector3D(WorldX, 0.0f, WorldZ);
	info.Normal = Vector3D(0, 1, 0); // Up vector

	float PointSizeX = m_Bounds.W / m_Size.X;
	float PointSizeZ = m_Bounds.H / m_Size.Y;

	int PosX = (int)(WorldX / PointSizeX + m_TerrainParams->Width / 2);
	int PosZ = (int)(WorldZ / PointSizeZ + m_TerrainParams->Height / 2);

	if (PosX > m_TerrainParams->Width - 1)
		PosX = m_TerrainParams->Width - 1;
	if (PosZ > m_TerrainParams->Height - 1)
		PosZ = m_TerrainParams->Height - 1;

	// Get the surrounding points
	int x1 = PosX + 1, z1 = PosZ + 1;
	if (x1 > m_TerrainParams->Width - 1)
		x1 = PosX;
	if (z1 > m_TerrainParams->Height - 1)
		z1 = PosZ;

	TerrainVertex verts[4];
	verts[0] = m_Vertices[PosX + PosZ * m_TerrainParams->Width];
	verts[1] = m_Vertices[PosX + z1 * m_TerrainParams->Width];
	verts[2] = m_Vertices[x1 + z1 * m_TerrainParams->Width];
	verts[3] = m_Vertices[x1 + PosZ * m_TerrainParams->Width];

	// Get the height using bilinear interpolation
	float x = (WorldX - verts[0].Pos.x) / PointSizeX; // 0 - 1
	float z = (WorldZ - verts[0].Pos.z) / PointSizeZ; // 0 - 1

	float xinv = 1 - x;
	float zinv = 1 - z;

	float y1, y2;

	y1 = verts[2].Pos.y * x + verts[1].Pos.y * xinv;
	y2 = verts[3].Pos.y * x + verts[0].Pos.y * xinv;

	float y = y1 * z + y2 * zinv;

	info.Position = Vector3D(WorldX, y, WorldZ);

	// todo Get the normal

	return info;
}
