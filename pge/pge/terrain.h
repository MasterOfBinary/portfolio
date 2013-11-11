//---------------------------------------------------------------------------
// terrain.h
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include "engine.h"
#include "exp.h"
#include "sceneobject.h"
#include "types.h"

#ifndef _TERRAIN_H_
#define _TERRAIN_H_

namespace pge
{
	namespace SceneObjects
	{
		struct TerrainVertex;

		struct PointInfo
		{
			Vector3D Position;
			Vector3D Normal;
		};

		struct TerrainParams
		{
			float *HeightData;
			Vector4D *TextureData;
			int Width;
			int Height;
			float HScale;
			float VScale;
			Vector2D TextureCoords;
			String *TexturePaths;
			int NumTextures; // 1 - 4 textures
			int NumSmoothingPasses;
		};

		class PGE_API TerrainLoader
		{
		public:
			static TerrainParams *LoadFromBitmap(String FileName);
		};

		class PGE_API Terrain : public SceneObject
		{
		public:
			Terrain(TerrainParams *Params);
			bool Create(Engine *ParentEngine);
			void DrawObject();
			void Destroy();

			Rect GetBounds();

			PointInfo GetTerrainPointInfo(float WorldX, float WorldZ);
		protected:
			ID3D10Effect *m_pEffect;
			ID3D10InputLayout *m_pVertexLayout;
			ID3D10Buffer *m_pVertexBuffer;
			ID3D10Buffer *m_pIndexBuffer;
			ID3D10EffectTechnique *m_pTechnique;
			ID3D10ShaderResourceView **m_pTextures;

			ID3D10EffectMatrixVariable *m_pWorldVariable;
			ID3D10EffectMatrixVariable *m_pViewVariable;
			ID3D10EffectMatrixVariable *m_pProjectionVariable;
			ID3D10EffectShaderResourceVariable *m_pTex1Variable;
			ID3D10EffectShaderResourceVariable *m_pTex2Variable;
			ID3D10EffectShaderResourceVariable *m_pTex3Variable;
			ID3D10EffectShaderResourceVariable *m_pTex4Variable;

			TerrainParams *m_TerrainParams;
			TerrainVertex *m_Vertices;
			int m_IndexSize;
			int m_NumTextures;
			Rect m_Bounds;
			Vector2D m_Size;
		};
	}
};

#endif // _TERRAIN_H_
