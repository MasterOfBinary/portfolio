//---------------------------------------------------------------------------
// font.h
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include "exp.h"

#ifndef _FONT_H_
#define _FONT_H_

namespace pge
{
	class Engine;

	struct FontParams
	{
		int Height;
		int Width;
		bool Bold;
		bool Italic;
		String FaceName;
	};

	class PGE_API Font
	{
	public:
		Font(FontParams *Params);
		bool Create(Engine *ParentEngine);
		void Destroy();

		void PreloadCharacters(UINT First, UINT Last);
		Rect GetStringRect(String Text);
		void DrawString(String Text, Rect Rect, Color Color, bool Clip = false);
	protected:
		Engine *m_Engine;
		ID3DX10Font *m_Font;

		FontParams *m_FontParams;
	};
};

#endif // _FONT_H_
