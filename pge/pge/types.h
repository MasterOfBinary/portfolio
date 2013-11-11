//---------------------------------------------------------------------------
// types.h
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include <d3d10.h>
#include <d3dx10.h>
#include <string>

#ifndef _TYPES_H_
#define _TYPES_H_

namespace pge
{
	#define Pi 3.14159265359f
	#define Pi2 6.28318530718f
	#define PiDiv2 1.57079632679f
	#define PiDiv3 1.04719755120f
	#define PiDiv4 0.78539816340f

	typedef D3DXMATRIX Matrix;
	typedef D3DXQUATERNION Quaternion;
	typedef std::string String;

	enum PGE_ENGINE_FORMAT
	{
		PGE_ENGINE_FORMAT_32_R8G8B8A8 = 28,
	};

	enum PGE_RETURN
	{
		PGE_RETURN_NOERROR,
		PGE_RETURN_INVALID_WINDOW,
		PGE_RETURN_ERROR_CREATING_DEVICE,
		PGE_RETURN_ERROR_CREATING_DEPTH_STENCIL,
	};

	struct PGE_API Color
	{
		Color();
		Color(float Red, float Green, float Blue);
		Color(float Red, float Green, float Blue, float Alpha);

		float R, G, B, A;
	};

	struct PGE_API Vector2D
	{
		Vector2D();
		Vector2D(float X, float Y);

		Vector2D operator+(const Vector2D &Vec);
		Vector2D operator+=(const Vector2D &Vec);
		Vector2D operator-(const Vector2D &Vec);
		Vector2D operator-=(const Vector2D &Vec);

		float X, Y;
	};

	struct PGE_API Vector3D
	{
		Vector3D();
		Vector3D(Vector2D Vec, float Z);
		Vector3D(float X, float Y, float Z);

		Vector3D operator+(const Vector3D &Vec);
		Vector3D operator+=(const Vector3D &Vec);
		Vector3D operator-(const Vector3D &Vec);
		Vector3D operator-=(const Vector3D &Vec);

		float X, Y, Z;
	};

	struct PGE_API Vector4D
	{
		Vector4D();
		Vector4D(Vector3D Vec, float W = 1.0f);
		Vector4D(float X, float Y, float Z, float W = 1.0f);

		Vector4D operator+(const Vector4D &Vec);
		Vector4D operator+=(const Vector4D &Vec);
		Vector4D operator-(const Vector4D &Vec);
		Vector4D operator-=(const Vector4D &Vec);

		float X, Y, Z, W;
	};

	struct PGE_API Rect
	{
		Rect();
		Rect(float X, float Y, float Width, float Height);
		Rect(Vector2D Pos, float Width, float Height);
		Rect(Vector2D Pos, Vector2D Size);

		float X, Y, W, H;
	};

	struct PGE_API BoundingSphere
	{
		BoundingSphere();
		BoundingSphere(Vector3D Pos, float Radius);

		bool Intersects(BoundingSphere *Sphere);

		Vector3D Pos;
		float Radius;
	};
};

#endif // _TYPES_H_
