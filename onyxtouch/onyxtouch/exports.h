//---------------------------------------------------------------------------
// exports.h
// OnyxTouch Ocean Rendering Library
// Copyright (c) 2013 ePeriod Software, All Rights Reserved
//---------------------------------------------------------------------------

#ifndef _EXPORTS_H_
#define _EXPORTS_H_

#ifdef ONYXTOUCH_EXPORTS
#define ONYXTOUCH_API __declspec(dllexport)
#else
#define ONYXTOUCH_API __declspec(dllimport)
#endif

#endif
