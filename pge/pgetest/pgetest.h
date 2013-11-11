#pragma once

#include <pge.h>
#include "gameobject.h"

// Macros
#define SafeDelete(x) { if (x) { delete (x); (x) = NULL; } }
#define ClearStruct(x) (ZeroMemory(&(x), sizeof(x)))
#define IsKeyDown(k) (GetAsyncKeyState(k) & 0x8000)
#define GetRelativeTime(t) (0.06f * (float)t)

inline String IntToString(int Number)
{
	ostringstream out;
	out << Number;
	return out.str();
}

using namespace pge;
using namespace pge::SceneObjects;
