//---------------------------------------------------------------------------
// mesh.h
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include "exp.h"
#include "sceneobject.h"
#include "types.h"

#ifndef _MESH_H_
#define _MESH_H_

namespace pge
{
	namespace SceneObjects
	{
		struct MeshVertex;

		struct MeshParams
		{
			Vector3D *Vertices;
			int NumVertices;
			Vector3D *Normals;
			Vector2D *TexCoords;
			UINT *Indices;
			int NumIndices;
		};

		class PGE_API MeshLoader
		{
		public:
			static MeshParams *LoadFromPGM(String FileName);
		};

		class PGE_API Mesh : public SceneObject
		{
		public:
			Mesh(MeshParams *Params);
			bool Create(Engine *ParentEngine);
			void DrawObject();
			void Destroy();

			void SetAmbientColor(Color Ambient);
			void SetDiffuseColor(Color Diffuse);
			//void SetTexture(String FileName);

			float GetMeshRadius();
		protected:
			ID3D10Effect *m_pEffect;
			ID3DX10Mesh *m_pMesh;
			ID3D10EffectTechnique *m_pTechnique;

			ID3D10EffectMatrixVariable *m_pWorldVariable;
			ID3D10EffectMatrixVariable *m_pViewVariable;
			ID3D10EffectMatrixVariable *m_pProjectionVariable;
			ID3D10EffectMatrixVariable *m_pViewInverseVariable;
			ID3D10EffectVectorVariable *m_pAmbientVariable;
			ID3D10EffectVectorVariable *m_pDiffuseVariable;
			ID3D10EffectScalarVariable *m_pTexturedVariable;
			ID3D10EffectShaderResourceVariable *m_pTexVariable;

			MeshParams *m_MeshParams;
			float m_MeshRadius;
		};
	};
};

#endif // _MESH_H_
