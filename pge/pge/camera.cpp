//---------------------------------------------------------------------------
// camera.cpp
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include "stdafx.h"
#include "pge.h"
#include "private.h"

using namespace pge;

#define UPDATE_VIEW_MATRIX() {   \
	D3DXVECTOR3 Eye = D3DXVECTOR3(m_Eye.X, m_Eye.Y, m_Eye.Z);   \
	D3DXVECTOR3 LookAt = D3DXVECTOR3(m_LookAt.X, m_LookAt.Y, m_LookAt.Z);   \
	D3DXVECTOR3 Up = D3DXVECTOR3(m_Up.X, m_Up.Y, m_Up.Z);   \
	D3DXMatrixLookAtLH(m_pViewMatrix, &Eye, &LookAt, &Up); }

Camera::Camera()
{
	// Initialize matrices
	m_pViewMatrix = new Matrix();
	D3DXMatrixIdentity(m_pViewMatrix);
}

bool Camera::Create(Engine *ParentEngine)
{
	return SceneObject::Create(ParentEngine);
}

void Camera::Destroy()
{
	SafeDelete(m_pViewMatrix);

	// SceneObject::Destroy() must be called last
	SceneObject::Destroy();
}

void Camera::DrawObject()
{ }

void Camera::SetAllVectors(Vector3D Eye, Vector3D LookAt, Vector3D Up)
{
	m_Eye = Eye;
	m_LookAt = LookAt;
	m_Up = Up;

	UPDATE_VIEW_MATRIX();
}

void Camera::TranslateEyeVector(Vector3D Eye)
{
	m_Eye += Eye;

	UPDATE_VIEW_MATRIX();
}

void Camera::TranslateLookAtVector(Vector3D LookAt)
{
	m_LookAt += LookAt;

	UPDATE_VIEW_MATRIX();
}

void Camera::SetEyeVector(Vector3D Eye)
{
	m_Eye = Eye;

	UPDATE_VIEW_MATRIX();
}

void Camera::SetLookAtVector(Vector3D LookAt)
{
	m_LookAt = LookAt;

	UPDATE_VIEW_MATRIX();
}

void Camera::SetUpVector(Vector3D Up)
{
	m_Up = Up;

	UPDATE_VIEW_MATRIX();
}

Matrix *Camera::GetViewMatrix()
{
	return m_pViewMatrix;
}