//---------------------------------------------------------------------------
// timer.cpp
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include "stdafx.h"
#include "pge.h"
#include "private.h"

using namespace pge;

void Timer::StartTimer()
{
	timeBeginPeriod(1); // Set 1ms period
	m_StartTime = timeGetTime();
}

DWORD Timer::ResetTimer()
{
	DWORD time = GetTimeElapsed();
	m_StartTime = timeGetTime();

	return time;
}

DWORD Timer::EndTimer()
{
	DWORD time = GetTimeElapsed();
	m_StartTime = 0;
	timeEndPeriod(1); // End 1ms period

	return time;
}

DWORD Timer::GetTimeElapsed()
{
	if (m_StartTime == 0)
		return 0;

	return timeGetTime() - m_StartTime;
}
