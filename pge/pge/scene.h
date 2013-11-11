//---------------------------------------------------------------------------
// scene.h
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include "exp.h"

#ifndef _SCENE_H_
#define _SCENE_H_

namespace pge
{
	class Engine;
	class SceneObjectCollection;

	class PGE_API Scene
	{
	public:
		Scene(Engine *ParentEngine);
		void Destroy(bool DeleteSceneObjects = true);
		
		SceneObjectCollection *GetObjectCollection();
		void DrawObjects();
	protected:
		Engine *m_Engine;
		SceneObjectCollection *m_ObjectCollection;
	};
};

#endif // _SCENE_H_
