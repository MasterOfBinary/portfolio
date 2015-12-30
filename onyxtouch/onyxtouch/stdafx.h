//---------------------------------------------------------------------------
// stdafx.h
// Private, this file is not to be distributed
// OnyxTouch Ocean Rendering Library
// Copyright (c) 2013 ePeriod Software, All Rights Reserved
//---------------------------------------------------------------------------
// Include file for standard system include files, or project specific
// include files that are used frequently, but are changed infrequently
//---------------------------------------------------------------------------

#pragma once

#include "targetver.h"

// Some stuff conflicts with parts of windows.h (specifically, parts of gameplay), so only
// include it when it's needed
#ifdef NEED_WINDOWS_H

#define WIN32_LEAN_AND_MEAN             // Exclude rarely-used stuff from Windows headers
// Windows Header Files:
#include <windows.h>

#endif // NEED_WINDOWS_H