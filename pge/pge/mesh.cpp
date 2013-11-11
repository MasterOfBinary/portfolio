//---------------------------------------------------------------------------
// mesh.cpp
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include "stdafx.h"
#include "pge.h"
#include "private.h"

using namespace pge;
using namespace pge::SceneObjects;

struct pge::SceneObjects::MeshVertex
{
	D3DXVECTOR3 Pos;  // Position
	D3DXVECTOR3 Norm; // Normal
	D3DXVECTOR2 TexCoord; // Texture coordinates
};

MeshParams *MeshLoader::LoadFromPGM(String FileName)
{
	ifstream infile;
	infile.open(FileName.c_str(), ios_base::in | ios_base::binary);
	if (!infile)
		return NULL;

#define Read(type, var) { infile.read(data, sizeof(type)); var = (*((type *)data)); }
#define ReadShort(s) Read(short, s);
#define ReadInt(i) Read(int, i);
#define ReadUint(i) Read(unsigned int, i);
#define ReadFloat(f) Read(float, f);
#define ReadVector2(v) { ReadFloat(v.X); ReadFloat(v.Y); }
#define ReadVector3(v) { ReadFloat(v.X); ReadFloat(v.Y); ReadFloat(v.Z); }

#define VERTEX_POSITION 0x0001
#define VERTEX_COLOR 0x0002
#define VERTEX_NORMAL 0x0004
#define VERTEX_TEXCOORDS 0x0008

	// The file header:
	// PGMxvvvv
	// Where
	//  x = The file version (currently 1)
	//  v = Offset to the vertex data
	char data[16];
	
	// Read the header
	infile.read(data, 4);

	// Check the header
	if ((data[0] != 'P') || (data[1] != 'G') || (data[2] != 'M'))
		return NULL;

	// Check the version number
	if (data[3] > 1)
		return NULL;

	// Get the vertex data offset
	int tmp;
	ReadInt(tmp);
	infile.seekg(tmp, ios_base::cur);

	// The vertex list:
	// nnnnssccvvvv...iiii
	// Where
	//  n = The number of vertices
	//  s = The size of each vertex
	//  c = The vertex components
	//  v = The list of vertices
	//  i = Offset to index data

	// Read the number of vertices, size and components
	int num;
	short size, components;
	ReadInt(num);
	ReadShort(size);
	ReadShort(components);

	// Now read the vertices
	Vector3D *vertices = new Vector3D[num];
	ZeroMemory(vertices, sizeof(Vector3D) * num);

	Vector3D *normals;
	if (components & VERTEX_NORMAL)
	{
		normals = new Vector3D[num];
		ZeroMemory(normals, sizeof(Vector3D) * num);
	}

	Vector2D *texcoords;
	if (components & VERTEX_TEXCOORDS)
	{
		texcoords = new Vector2D[num];
		ZeroMemory(texcoords, sizeof(Vector2D) * num);
	}

	for (int x = 0; x < num; x++)
	{
		if (components & VERTEX_POSITION)
			ReadVector3(vertices[x]);
		if (components & VERTEX_NORMAL)
			ReadVector3(normals[x]);
		if (components & VERTEX_TEXCOORDS)
			ReadVector2(texcoords[x]);
	}

	MeshParams *p = new MeshParams();
	ZeroMemory(p, sizeof(MeshParams));
	p->Vertices = vertices;
	p->NumVertices = num;
	if (components & VERTEX_NORMAL)
		p->Normals = normals;
	if (components & VERTEX_TEXCOORDS)
		p->TexCoords = texcoords;

	// Read the index data offset
	ReadInt(tmp);
	infile.seekg(tmp, ios_base::cur);

	// The index list:
	// nnnnssiiii...
	// Where
	//  n = The number of indices
	//  s = The size of each index
	//  i = The list of indices
	
	ReadInt(num);
	ReadShort(size);

	// Now read the indices
	UINT *indices = new UINT[num];
	for (int x = 0; x < num; x++)
		ReadUint(indices[x]);

	// Close the file
	infile.close();

	p->Indices = indices;
	p->NumIndices = num;

	return p;
}

Mesh::Mesh(MeshParams *Params)
{
	m_pEffect = NULL;
	m_pMesh = NULL;
	m_pTechnique = NULL;

	m_pWorldVariable = NULL;
	m_pViewVariable = NULL;
	m_pProjectionVariable = NULL;
	m_pViewInverseVariable = NULL;
	m_pAmbientVariable = NULL;
	m_pDiffuseVariable = NULL;
	m_pTexturedVariable = NULL;

	m_MeshParams = new MeshParams();
	*m_MeshParams = *Params;

	m_MeshRadius = 0;
}

bool Mesh::Create(pge::Engine *ParentEngine)
{
	if (!SceneObject::Create(ParentEngine))
		return false;

	HRESULT hr = S_OK;

	ID3D10Device *pd3dDevice = ParentEngine->GetD3D10Device();

	// Create the effect
	hr = D3DX10CreateEffectFromFile(L"mesh.fx", NULL, NULL, "fx_4_0",
		D3D10_SHADER_ENABLE_STRICTNESS, 0, pd3dDevice, NULL, NULL, &m_pEffect, NULL, NULL);
	if (FAILED(hr))
		return false;

    // Obtain the technique
	m_pTechnique = m_pEffect->GetTechniqueByName("Render");

	// Obtain the variables
    m_pWorldVariable = m_pEffect->GetVariableByName("World")->AsMatrix();
    m_pViewVariable = m_pEffect->GetVariableByName("View")->AsMatrix();
    m_pProjectionVariable = m_pEffect->GetVariableByName("Projection")->AsMatrix();
    m_pViewInverseVariable = m_pEffect->GetVariableByName("ViewInverse")->AsMatrix();
	m_pAmbientVariable = m_pEffect->GetVariableByName("AmbientColor")->AsVector();
	m_pDiffuseVariable = m_pEffect->GetVariableByName("DiffuseColor")->AsVector();
	m_pTexturedVariable = m_pEffect->GetVariableByName("Textured")->AsScalar();
	m_pTexVariable = m_pEffect->GetVariableByName("tx")->AsShaderResource();

	// Define the input layout
	D3D10_INPUT_ELEMENT_DESC layout[] =
	{
		{ "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 0, D3D10_INPUT_PER_VERTEX_DATA, 0 },
		{ "NORMAL", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 12, D3D10_INPUT_PER_VERTEX_DATA, 0 },
		{ "TEXCOORD", 0, DXGI_FORMAT_R32G32_FLOAT, 0, 24, D3D10_INPUT_PER_VERTEX_DATA, 0 },
	};

	UINT numElements = sizeof(layout) / sizeof(layout[0]);

	// Create the mesh
	hr = D3DX10CreateMesh(pd3dDevice, layout, numElements, "POSITION",
		m_MeshParams->NumVertices, m_MeshParams->NumIndices / 3, D3DX10_MESH_32_BIT,
		&m_pMesh);
	if (FAILED(hr))
		return false;

	// Create vertices
	MeshVertex *vertices = new MeshVertex[m_MeshParams->NumVertices];
	ZeroMemory(vertices, sizeof(MeshVertex) * m_MeshParams->NumVertices);

	Vector3D *farthest = NULL;
	float dist = 0.0f;

	for (int x = 0; x < m_MeshParams->NumVertices; x++)
	{
		Vector3D *vertex = &m_MeshParams->Vertices[x];
		vertices[x].Pos = D3DXVECTOR3(vertex->X, vertex->Y, vertex->Z);

		// Calculate approx distance
		float vertexdist = vertex->X + vertex->Y + vertex->Z;
		if (vertexdist > dist)
		{
			dist = vertexdist;
			farthest = vertex;
		}
	}

	m_MeshRadius = sqrt(farthest->X * farthest->X +
		farthest->Y * farthest->Y +
		farthest->Z * farthest->Z);

	if (m_MeshParams->Normals)
	{
		for (int x = 0; x < m_MeshParams->NumVertices; x++)
		{
			Vector3D *normal = &m_MeshParams->Normals[x];
			vertices[x].Norm = D3DXVECTOR3(normal->X, normal->Y, normal->Z);
		}
	}

	if (m_MeshParams->TexCoords)
	{
		for (int x = 0; x < m_MeshParams->NumVertices; x++)
		{
			Vector2D *texcoord = &m_MeshParams->TexCoords[x];
			vertices[x].TexCoord = D3DXVECTOR2(texcoord->X, texcoord->Y);
		}
	}

	hr = m_pMesh->SetVertexData(0, vertices);
	if (FAILED(hr))
		return false;

	UINT *indices = new UINT[m_MeshParams->NumIndices];

	for (int x = 0; x < m_MeshParams->NumIndices; x++)
		indices[x] = m_MeshParams->Indices[x];

	hr = m_pMesh->SetIndexData(indices, m_MeshParams->NumIndices);
	if (FAILED(hr))
		return false;

	return true;
}

void Mesh::DrawObject()
{
	HRESULT hr = S_OK;

	ID3D10Device *pd3dDevice = m_pEngine->GetD3D10Device();

	// Commit mesh to device
	m_pMesh->CommitToDevice();

	// Set our matrices
	Matrix ViewInverse;
	D3DXMatrixInverse(&ViewInverse, NULL, m_pEngine->GetCurrentCamera()->GetViewMatrix());
	m_pWorldVariable->SetMatrix((float *)m_WorldMatrix);
	m_pViewVariable->SetMatrix((float *)m_pEngine->GetCurrentCamera()->GetViewMatrix());
	m_pProjectionVariable->SetMatrix((float *)m_pEngine->GetProjectionMatrix());
	m_pViewInverseVariable->SetMatrix((float *)ViewInverse);
	m_pTexturedVariable->SetBool(m_MeshParams->TexCoords != NULL);

	// Render the mesh
	D3D10_TECHNIQUE_DESC techDesc;
	m_pTechnique->GetDesc(&techDesc);
	for (UINT p = 0; p < techDesc.Passes; ++p)
	{
		m_pTechnique->GetPassByIndex(p)->Apply(0);
		m_pMesh->DrawSubset(0);
	}
}

void Mesh::Destroy()
{
	SafeRelease(m_pMesh);
    SafeRelease(m_pEffect);
	SafeDelete(m_MeshParams); 

	// SceneObject::Destroy() must be called last
	SceneObject::Destroy();
}

void Mesh::SetAmbientColor(Color Ambient)
{
	float Color[] =
	{
		Ambient.R, Ambient.G, Ambient.B, Ambient.A
	};

	m_pAmbientVariable->SetFloatVector(Color);
}

void Mesh::SetDiffuseColor(Color Diffuse)
{
	float Color[] =
	{
		Diffuse.R, Diffuse.G, Diffuse.B, Diffuse.A
	};

	m_pDiffuseVariable->SetFloatVector(Color);
}

//void Mesh::SetTexture(String FileName)
//{
//	if (FAILED(D3DX10CreateShaderResourceViewFromFileA(pd3dDevice, m_TerrainParams->TexturePaths[x].c_str(),
//		NULL, NULL, &m_pTextures, NULL))
//		return;
//}

float Mesh::GetMeshRadius()
{
	return m_MeshRadius;
}
