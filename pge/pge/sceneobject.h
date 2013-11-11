//---------------------------------------------------------------------------
// sceneobject.h
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include "exp.h"
#include "types.h"

#ifndef _SCENEOBJECT_H_
#define _SCENEOBJECT_H_

namespace pge
{
	class Engine;

	class PGE_API SceneObject
	{
	public:
		SceneObject();
		virtual bool Create(Engine *ParentEngine);
		virtual void DrawObject() = 0;
		virtual void Destroy();

		virtual void SetWorldMatrix(Matrix *WorldMatrix);
		virtual Matrix *GetWorldMatrix();
	protected:
		Engine *m_pEngine;

		Matrix *m_WorldMatrix;
	};
};

#endif // _SCENEOBJECT_H_
