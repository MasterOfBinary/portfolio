//---------------------------------------------------------------------------
// bitmap.cpp
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include "stdafx.h"
#include "pge.h"
#include "private.h"

using namespace pge;

#define Read4(x) { m_InFile.read(&c[0], 4); x = CharArray4ToInt(c); }

Bitmap::Bitmap(String FileName)
{
	m_Width = 0;
	m_Height = 0;
	m_BitDepth = 0;
	m_BytesPerPixel = 0;
	m_BitmapData = NULL;

	UINT offset;
	UINT w, h;
	UINT bpp;

	m_InFile.open(FileName.c_str(), ios_base::in | ios_base::binary);
	if (!m_InFile)
		return;

	char c[4];
	m_InFile.seekg(10, ios_base::cur);
	Read4(offset);
	m_InFile.seekg(4, ios_base::cur);
	Read4(w);
	Read4(h);
	m_InFile.seekg(2, ios_base::cur);
	Read4(bpp);
	m_InFile.seekg(offset, ios_base::beg);

	m_Width = w;
	m_Height = h;
	m_BitDepth = bpp;

	m_BytesPerPixel = bpp / 8;
	m_BitmapData = new char[w * h * m_BytesPerPixel];

	m_InFile.read(m_BitmapData, w * h * m_BytesPerPixel);

	m_InFile.close();
}

Bitmap::~Bitmap()
{
	if (m_BitmapData)
		delete []m_BitmapData;
}

char *Bitmap::GetPixel(UINT X, UINT Y)
{
	if ((X > m_Width - 1) || (Y > m_Height - 1))
		return NULL;

	char *pixel = new char[m_BytesPerPixel];
	int index = X + (m_Width - Y - 1) * m_Width;
	for (UINT x = 0; x < m_BytesPerPixel; x++)
		pixel[x] = m_BitmapData[index + x];

	return pixel;
}

UINT Bitmap::GetWidth()
{
	return m_Width;
}

UINT Bitmap::GetHeight()
{
	return m_Height;
}

UINT Bitmap::GetBitDepth()
{
	return m_BitDepth;
}
