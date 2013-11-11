//---------------------------------------------------------------------------
// types.cpp
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include "stdafx.h"
#include "pge.h"
#include "private.h"

using namespace pge;

Color::Color()
{
	R = G = B = 0.0f;
	A = 1.0f;
}

Color::Color(float Red, float Green, float Blue)
{
	R = Red;
	G = Green;
	B = Blue;
	A = 1.0;
}

Color::Color(float Red, float Green, float Blue, float Alpha)
{
	R = Red;
	G = Green;
	B = Blue;
	A = Alpha;
}

Vector2D::Vector2D()
{
	X = Y = 0.0f;
}

Vector2D::Vector2D(float X, float Y)
{
	this->X = X;
	this->Y = Y;
}

Vector2D Vector2D::operator+(const Vector2D &Vec)
{
	return Vector2D(X + Vec.X, Y + Vec.Y);
}

Vector2D Vector2D::operator+=(const Vector2D &Vec)
{
	X += Vec.X;
	Y += Vec.Y;
	return Vector2D(X, Y);
}

Vector2D Vector2D::operator-(const Vector2D &Vec)
{
	return Vector2D(X - Vec.X, Y - Vec.Y);
}

Vector2D Vector2D::operator-=(const Vector2D &Vec)
{
	X -= Vec.X;
	Y -= Vec.Y;
	return Vector2D(X, Y);
}


Vector3D::Vector3D()
{
	X = Y = Z = 0.0f;
}

Vector3D::Vector3D(Vector2D Vec, float Z)
{
	X = Vec.X;
	Y = Vec.Y;
	this->Z = Z;
}

Vector3D::Vector3D(float X, float Y, float Z)
{
	this->X = X;
	this->Y = Y;
	this->Z = Z;
}

Vector3D Vector3D::operator+(const Vector3D &Vec)
{
	return Vector3D(X + Vec.X, Y + Vec.Y, Z + Vec.Z);
}

Vector3D Vector3D::operator+=(const Vector3D &Vec)
{
	X += Vec.X;
	Y += Vec.Y;
	Z += Vec.Z;
	return Vector3D(X, Y, Z);
}

Vector3D Vector3D::operator-(const Vector3D &Vec)
{
	return Vector3D(X - Vec.X, Y - Vec.Y, Z - Vec.Z);
}

Vector3D Vector3D::operator-=(const Vector3D &Vec)
{
	X -= Vec.X;
	Y -= Vec.Y;
	Z -= Vec.Z;
	return Vector3D(X, Y, Z);
}


Vector4D::Vector4D()
{
	X = Y = Z = 0.0f;
	W = 1.0f;
}

Vector4D::Vector4D(Vector3D Vec, float W)
{
	X = Vec.X;
	Y = Vec.Y;
	Z = Vec.Z;
	this->W = W;
}

Vector4D::Vector4D(float X, float Y, float Z, float W)
{
	this->X = X;
	this->Y = Y;
	this->Z = Z;
	this->W = W;
}

Vector4D Vector4D::operator+(const Vector4D &Vec)
{
	return Vector4D(X + Vec.X, Y + Vec.Y, Z + Vec.Z, W + Vec.W);
}

Vector4D Vector4D::operator+=(const Vector4D &Vec)
{
	X += Vec.X;
	Y += Vec.Y;
	Z += Vec.Z;
	W += Vec.W;
	return Vector4D(X, Y, Z, W);
}

Vector4D Vector4D::operator-(const Vector4D &Vec)
{
	return Vector4D(X - Vec.X, Y - Vec.Y, Z - Vec.Z, W - Vec.W);
}

Vector4D Vector4D::operator-=(const Vector4D &Vec)
{
	X -= Vec.X;
	Y -= Vec.Y;
	Z -= Vec.Z;
	W -= Vec.W;
	return Vector4D(X, Y, Z, W);
}


Rect::Rect()
{
	X = Y = W = H = 0.0f;
}

Rect::Rect(float X, float Y, float Width, float Height)
{
	this->X = X;
	this->Y = Y;
	W = Width;
	H = Height;
}

Rect::Rect(Vector2D Pos, float Width, float Height)
{
	X = Pos.X;
	Y = Pos.Y;
	W = Width;
	H = Height;
}

Rect::Rect(Vector2D Pos, Vector2D Size)
{
	X = Pos.X;
	Y = Pos.Y;
	W = Size.X;
	H = Size.Y;
}


BoundingSphere::BoundingSphere()
{
	Radius = 0.0f;
}

BoundingSphere::BoundingSphere(Vector3D Pos, float Radius)
{
	this->Pos.X = Pos.X;
	this->Pos.Y = Pos.Y;
	this->Pos.Z = Pos.Z;
	this->Radius = Radius;
}

bool BoundingSphere::Intersects(BoundingSphere *Sphere)
{
	// x^2 + y^2 + z^2 = r^2
	float Distance = Radius + Sphere->Radius;
	float DistX = Pos.X - Sphere->Pos.X;
	float DistY = Pos.Y - Sphere->Pos.Y;
	float DistZ = Pos.Z - Sphere->Pos.Z;
	
	return (DistX * DistX + DistY * DistY + DistZ * DistZ <= Distance * Distance);
}