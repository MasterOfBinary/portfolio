//---------------------------------------------------------------------------
// sceneobject.cpp
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include "stdafx.h"
#include "pge.h"
#include "private.h"

using namespace pge;

SceneObject::SceneObject()
{
	m_WorldMatrix = new Matrix();
	D3DXMatrixIdentity(m_WorldMatrix);
}

bool SceneObject::Create(Engine *ParentEngine)
{
	m_pEngine = ParentEngine;
	return true;
}

void SceneObject::Destroy()
{
	SafeDelete(m_WorldMatrix);

	delete this;
}

void SceneObject::SetWorldMatrix(Matrix *WorldMatrix)
{
	*m_WorldMatrix = *WorldMatrix;
}

Matrix *SceneObject::GetWorldMatrix()
{
	return m_WorldMatrix;
}
