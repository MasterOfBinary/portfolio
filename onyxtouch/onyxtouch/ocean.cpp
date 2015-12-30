//---------------------------------------------------------------------------
// ocean.cpp
// Private, this file is not to be distributed
// OnyxTouch Ocean Rendering Library
// Copyright (c) 2013 ePeriod Software, All Rights Reserved
//---------------------------------------------------------------------------
// The following versions are allowed, and the code for that version only is
// included:
//   ONYXTOUCH_VER_GAMEPLAY: ocean-gameplay.cpp
// Planned:
//   ONYXTOUCH_VER_DX_GL: ocean-dx11.cpp, ocean-gl3.cpp
// When building for a specific version, only the ocean-*.cpp files that are
// actually needed for that version should be included.
//---------------------------------------------------------------------------

#include "stdafx.h"
#include "ocean.h"
#include "ocean-impl.h"
#include "onyxtouch.h"

// Include the right implementations of Ocean
#ifdef ONYXTOUCH_VER_GAMEPLAY
#include "ocean-gameplay.h"
#endif // ONYXTOUCH_VER_GAMEPLAY

using namespace onyxtouch;

//
// Constructors and destructors
//

Ocean::Ocean(OnyxTouch *ot, Type type, void *params, const Vec2 &size, const Vec2 &wind) {
	switch (ot->getPlatform()) {
#ifdef ONYXTOUCH_VER_GAMEPLAY
	case OnyxTouch::GAMEPLAY:
		impl = (OceanImpl *)new OceanGameplay(ot, type, (GameplayParams *)params, size, wind);
		break;
#endif
	};
}

Ocean::~Ocean() {
	delete impl;
}

//
// Initialization and termination
//

Ocean::Error Ocean::initialize() {
	return impl->initialize();
}

void Ocean::terminate() {
	impl->terminate();
}

//
// Ocean rendering and updating
//

void Ocean::update(float elapsedTime) {
	impl->update(elapsedTime);
}

//
// Protected copying stuff so the user can't copy
//

Ocean::Ocean(const Ocean &) { }

Ocean &Ocean::operator=(const Ocean &) {
	return *this;
}