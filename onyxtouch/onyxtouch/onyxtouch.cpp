//---------------------------------------------------------------------------
// onyxtouch.cpp
// Private, this file is not to be distributed
// OnyxTouch Ocean Rendering Library
// Copyright (c) 2013 ePeriod Software, All Rights Reserved
//---------------------------------------------------------------------------

#include "stdafx.h"
#include "onyxtouch.h"
#include "ocean.h"

using namespace onyxtouch;

//
// Constructors and destructors
//

OnyxTouch::OnyxTouch(Platform platform)
	: platform(platform) { }

OnyxTouch::~OnyxTouch() { }

//
// Initialization and termination
//

OnyxTouch::Error OnyxTouch::initialize() {
	return OnyxTouch::SUCCESS;
}

void OnyxTouch::terminate() {

}

//
// Protected copying stuff so the user can't copy
//

OnyxTouch::OnyxTouch(const OnyxTouch &)
	: platform(OnyxTouch::GAMEPLAY) { }

OnyxTouch &OnyxTouch::operator=(const OnyxTouch &) {
	return *this;
}