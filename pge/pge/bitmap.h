//---------------------------------------------------------------------------
// bitmap.h
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include <fstream>

#include "exp.h"
#include "types.h"

#ifndef _BITMAP_H_
#define _BITMAP_H_

namespace pge
{
	class PGE_API Bitmap
	{
	public:
		Bitmap(String FileName);
		~Bitmap();

		char *GetPixel(UINT X, UINT Y);

		UINT GetWidth();
		UINT GetHeight();
		UINT GetBitDepth();
	protected:
		UINT m_Width;
		UINT m_Height;
		UINT m_BitDepth;
		UINT m_BytesPerPixel;
		char *m_BitmapData;
		std::ifstream m_InFile;
	};
}

#endif // _BITMAP_H_
