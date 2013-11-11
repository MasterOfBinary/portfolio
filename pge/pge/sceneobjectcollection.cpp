//---------------------------------------------------------------------------
// sceneobjectcollection.cpp
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include "stdafx.h"
#include "pge.h"
#include "private.h"

using namespace pge;

SceneObjectIndex::SceneObjectIndex(SceneObject *SceneObject)
{
	m_SceneObject = SceneObject;
	m_PreviousSceneObject = NULL;
	m_NextSceneObject = NULL;
}

SceneObjectIterator::SceneObjectIterator(SceneObjectIndex *m_FirstSceneObject)
{
	m_CurrentIndex = m_FirstSceneObject;
}

void SceneObjectIterator::Decrement()
{
	m_CurrentIndex = m_CurrentIndex->m_PreviousSceneObject;
}

void SceneObjectIterator::Increment()
{
	m_CurrentIndex = m_CurrentIndex->m_NextSceneObject;
}

SceneObject *SceneObjectIterator::GetObject()
{
	if (m_CurrentIndex == NULL)
		return NULL;

	return m_CurrentIndex->m_SceneObject;
}

SceneObjectCollection::SceneObjectCollection()
{
	m_NumberOfSceneObjects = 0;
	m_FirstSceneObject = NULL;
	m_LastSceneObject = NULL;
}

void SceneObjectCollection::Destroy(bool DeleteSceneObjects)
{
	// Delete the scene objects
	SceneObjectIndex *NextIndex = m_FirstSceneObject;
	SceneObjectIndex *CurrentIndex;
	while (1)
	{
		if (NextIndex == NULL)
			break;

		CurrentIndex = NextIndex;

		// We only want to delete the actual scene object if DeleteSceneObjects is true
		if (DeleteSceneObjects)
			NextIndex->m_SceneObject->Destroy();

		NextIndex = NextIndex->m_NextSceneObject;

		// Delete the scene object index, which is basically just a pointer to the scene
		// object
		SafeDelete(CurrentIndex);
	}

	delete this;
}

void SceneObjectCollection::AddSceneObject(SceneObject *Object)
{
	if (Object == NULL)
		return;

	SceneObjectIndex *Index = new SceneObjectIndex(Object);

	if (m_NumberOfSceneObjects == 0)
	{
		// No scene objects yet
		m_FirstSceneObject = Index;
		m_LastSceneObject = Index;
	}
	else
	{
		m_LastSceneObject->m_NextSceneObject = Index;
		Index->m_PreviousSceneObject = m_LastSceneObject;

		m_LastSceneObject = Index;
	}

	m_NumberOfSceneObjects++;
}

bool SceneObjectCollection::CreateAllSceneObjects(Engine *ParentEngine)
{
	SceneObjectIndex *NextIndex = m_FirstSceneObject;

	bool Success = true;

	while (1)
	{
		if (NextIndex == NULL)
			break;

		if (!NextIndex->m_SceneObject->Create(ParentEngine))
			Success = false;

		NextIndex = NextIndex->m_NextSceneObject;
	}

	return Success;
}

SceneObjectIterator *SceneObjectCollection::GetSceneObjectIterator()
{
	return new SceneObjectIterator(m_FirstSceneObject);
}
