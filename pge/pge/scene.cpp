//---------------------------------------------------------------------------
// scene.cpp
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include "stdafx.h"
#include "pge.h"
#include "private.h"

#include <vector>

using namespace pge;
using namespace std;

Scene::Scene(Engine *ParentEngine)
{
	m_Engine = ParentEngine;
	m_ObjectCollection = new SceneObjectCollection();
}

void Scene::Destroy(bool DeleteSceneObjects)
{
	m_ObjectCollection->Destroy(DeleteSceneObjects);
	delete this;
}

SceneObjectCollection *Scene::GetObjectCollection()
{
	return m_ObjectCollection;
}

void Scene::DrawObjects()
{
	SceneObjectIterator *Iterator = m_ObjectCollection->GetSceneObjectIterator();
	while (Iterator->GetObject() != NULL)
	{
		Iterator->GetObject()->DrawObject();
		Iterator->Increment();
	}
	delete Iterator;
}