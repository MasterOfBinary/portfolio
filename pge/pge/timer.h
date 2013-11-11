//---------------------------------------------------------------------------
// timer.h
// Perspective GX Game Engine
// Copyright (c) 2008 ePeriod Games, All Rights Reserved
//---------------------------------------------------------------------------

#include "exp.h"

#ifndef _TIMER_H_
#define _TIMER_H_

namespace pge
{
	class PGE_API Timer
	{
	public:
		void StartTimer();
		DWORD ResetTimer();
		DWORD EndTimer();
		DWORD GetTimeElapsed();
	protected:
		DWORD m_StartTime;
	};
};

#endif // _TIMER_H_
