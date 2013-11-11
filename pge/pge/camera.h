//---------------------------------------------------------------------------
// camera.h
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include <d3dx10.h>

#include "exp.h"
#include "sceneobject.h"
#include "types.h"

#ifndef _CAMERA_H_
#define _CAMERA_H_

namespace pge
{
	class PGE_API Camera : protected SceneObject
	{
	public:
		Camera();
		bool Create(Engine *ParentEngine);
		void DrawObject();
		void Destroy();

		void SetAllVectors(Vector3D Eye, Vector3D LookAt, Vector3D Up);

		void TranslateEyeVector(Vector3D Eye);
		void TranslateLookAtVector(Vector3D LookAt);

		void SetEyeVector(Vector3D Eye);
		void SetLookAtVector(Vector3D LookAt);
		void SetUpVector(Vector3D Up);

		Matrix *GetViewMatrix();
	protected:
		Matrix *m_pViewMatrix;

		Vector3D m_Eye;
		Vector3D m_LookAt;
		Vector3D m_Up;
	};
};

#endif // _CAMERA_H_
