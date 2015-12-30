//---------------------------------------------------------------------------
// ocean-gameplay.h
// Private, this file is not to be distributed
// OnyxTouch Ocean Rendering Library
// Copyright (c) 2013 ePeriod Software, All Rights Reserved
//---------------------------------------------------------------------------
// The ocean class for the gameplay platform.
//---------------------------------------------------------------------------

#ifdef ONYXTOUCH_VER_GAMEPLAY

#ifndef _OCEAN_GAMEPLAY_H_
#define _OCEAN_GAMEPLAY_H_

#include "exports.h"
#include "ocean.h"
#include "ocean-impl.h"

// Gameplay gives lots of warnings when using warning level 4
#pragma warning(push, 3)
#include "gameplay.h"
#pragma warning(pop)

namespace onyxtouch {

class OceanGameplay : public Ocean::OceanImpl {
public:
	OceanGameplay(OnyxTouch *ot, Ocean::Type type, GameplayParams *params, const Vec2 &size, const Vec2 &wind);
	~OceanGameplay();

	Ocean::Error initialize();
	void terminate();

	// Elapsed time is in seconds
	void update(float elapsedTime);
	
protected:
	gameplay::Vector2 wind;
	gameplay::Node *node;
	gameplay::Texture::Sampler *tex;
};

};

#endif // _OCEAN_GAMEPLAY_H_

#endif // ONYXTOUCH_VER_GAMEPLAY