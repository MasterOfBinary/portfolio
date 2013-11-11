//---------------------------------------------------------------------------
// private.h
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
// Private file
// FOR INTERNAL USE ONLY
//---------------------------------------------------------------------------

#ifndef _PRIVATE_H_
#define _PRIVATE_H_

// Macros
#define ClearStruct(x) ZeroMemory(&(x), sizeof(x))
#define SafeRelease(x) { if (x) { (x)->Release(); (x) = NULL; } }
#define SafeDelete(x) { if (x) { delete (x); (x) = NULL; } }
#define SafeCheckResult(hr, ret) { if (FAILED(hr)) { Destroy(); return (ret); } }
#define ColorIntToFloat(x) (((float)(x)) / 255.0f)
#define ColorToFloat4(c) { c.R, c.G, c.B, c.A }
#define CharArray2ToInt(a) ((a[0]) + (a[1] << 8))
#define CharArray3ToInt(a) ((a[0]) + (a[1] << 8) + (a[2] << 16))
#define CharArray4ToInt(a) ((a[0]) + (a[1] << 8) + (a[2] << 16) + (a[3] << 24))

#endif // _PRIVATE_H_
