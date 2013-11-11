//---------------------------------------------------------------------------
// font.cpp
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include "stdafx.h"
#include "pge.h"
#include "private.h"

using namespace pge;

Font::Font(FontParams *Params)
{
	m_Engine = NULL;
	m_Font = NULL;

	m_FontParams = new FontParams();
	*m_FontParams = *Params;
}

bool Font::Create(Engine *ParentEngine)
{
	m_Engine = ParentEngine;

	HRESULT hr = S_OK;

	ID3D10Device *pd3dDevice = ParentEngine->GetD3D10Device();

	// Create the font
	hr = D3DX10CreateFontA(pd3dDevice, m_FontParams->Width, m_FontParams->Height,
		(m_FontParams->Bold ? FW_BOLD : FW_NORMAL), 1, m_FontParams->Italic,
		ANSI_CHARSET, OUT_DEFAULT_PRECIS, DEFAULT_QUALITY, FF_DONTCARE,
		m_FontParams->FaceName.c_str(), &m_Font);

	return true;
}

void Font::Destroy()
{
	SafeRelease(m_Font);

	delete this;
}

void Font::PreloadCharacters(UINT First, UINT Last)
{
	m_Font->PreloadCharacters(First, Last);
}

Rect Font::GetStringRect(String Text)
{
	RECT rect;
	ClearStruct(rect);
	m_Font->DrawTextA(NULL, Text.c_str(), (INT)Text.length(), &rect, DT_CALCRECT, D3DXCOLOR());
	Rect ret;
	ret.X = (float)rect.left;
	ret.Y = (float)rect.top;
	ret.W = (float)rect.right - rect.left;
	ret.H = (float)rect.bottom - rect.top;
	return ret;
}

void Font::DrawString(String Text, Rect Rect, Color Color, bool Clip)
{
	RECT rect;
	rect.left = (LONG)Rect.X;
	rect.top = (LONG)Rect.Y;
	rect.right = (LONG)(Rect.X + Rect.W);
	rect.bottom = (LONG)(Rect.Y + Rect.H);
	D3DXCOLOR col;
	col.r = Color.R;
	col.g = Color.G;
	col.b = Color.B;
	col.a = Color.A;
	m_Font->DrawTextA(NULL, Text.c_str(), (INT)Text.length(), &rect, (Clip ? 0 : DT_NOCLIP), col);
}
