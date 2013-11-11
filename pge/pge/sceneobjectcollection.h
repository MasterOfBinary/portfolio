//---------------------------------------------------------------------------
// sceneobjectcollection.h
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include "exp.h"

#ifndef _SCENEOBJECTCOLLECTION_H_
#define _SCENEOBJECTCOLLECTION_H_

namespace pge
{
	class SceneObject;

	struct SceneObjectIndex
	{
		SceneObjectIndex(SceneObject *SceneObject);

		SceneObject *m_SceneObject;

		SceneObjectIndex *m_PreviousSceneObject;
		SceneObjectIndex *m_NextSceneObject;
	};

	class PGE_API SceneObjectIterator
	{
	public:
		SceneObjectIterator(SceneObjectIndex *m_FirstSceneObject);

		void Decrement();
		void Increment();
		SceneObject *GetObject();
	private:
		SceneObjectIndex *m_CurrentIndex;
	};

	class PGE_API SceneObjectCollection
	{
	public:
		SceneObjectCollection();
		void Destroy(bool DeleteSceneObjects = true);

		void AddSceneObject(SceneObject *Object);
		bool CreateAllSceneObjects(Engine *ParentEngine);

		SceneObjectIterator *GetSceneObjectIterator();
	private:
		int m_NumberOfSceneObjects;

		SceneObjectIndex *m_FirstSceneObject;
		SceneObjectIndex *m_LastSceneObject;
	};
};

#endif // _SCENEOBJECTCOLLECTION_H_
