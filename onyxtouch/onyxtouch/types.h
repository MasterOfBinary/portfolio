//---------------------------------------------------------------------------
// types.h
// OnyxTouch Ocean Rendering Library
// Copyright (c) 2013 ePeriod Software, All Rights Reserved
//---------------------------------------------------------------------------

#ifndef _TYPES_H_
#define _TYPES_H_

#include "exports.h"
#include <cmath>

#ifndef M_PI
#define M_PI 3.14159265f
#endif

#define FLOAT_TOLERANCE 0.00000001f
#define FLOAT_IS_ZERO(x) (abs(x) < FLOAT_TOLERANCE)

struct ONYXTOUCH_API Vec2 {
	float x, y;

	inline Vec2() : x(0.0f), y(0.0f) { }
	inline Vec2(float x, float y) : x(x), y(y) { }
	inline Vec2(const Vec2 &copy) : x(copy.x), y(copy.y) { }

	inline float length() { return sqrt(x * x + y * y); }
	inline void normalize(Vec2 *vec) {
		float len = length();
		vec->x = x / len;
		vec->y = y / len;
	}
	inline float dot(const Vec2 &other) { return (x * other.x + y * other.y); }
};

#endif // _TYPES_H_