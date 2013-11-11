//---------------------------------------------------------------------------
// random.h
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include "exp.h"

#ifndef _RANDOM_H_
#define _RANDOM_H_

namespace pge
{
	class PGE_API Random
	{
	public:
		Random();

		int NextInt();
		int NextInt(int Max);
		int NextInt(int Min, int Max);
	};
};

#endif // _RANDOM_H_
