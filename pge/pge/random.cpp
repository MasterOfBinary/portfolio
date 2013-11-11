//---------------------------------------------------------------------------
// random.cpp
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include "stdafx.h"
#include "pge.h"
#include "private.h"

using namespace pge;

Random::Random()
{
	// Seed the random generator with the current time
	srand(timeGetTime());
}

int Random::NextInt()
{
	return rand();
}

int Random::NextInt(int Max)
{
	return NextInt(0, Max);
}

int Random::NextInt(int Min, int Max)
{
	return (int)((double)rand() / (RAND_MAX + 1) * (Max - Min) + Min);
}
