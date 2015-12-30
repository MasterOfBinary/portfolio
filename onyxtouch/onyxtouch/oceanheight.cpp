//---------------------------------------------------------------------------
// oceanheight.cpp
// Private, this file is not to be distributed
// OnyxTouch Ocean Rendering Library
// Copyright (c) 2013 ePeriod Software, All Rights Reserved
//---------------------------------------------------------------------------
// TODO remove platform-specific stuff from this file.
//---------------------------------------------------------------------------

#include "stdafx.h"
#include "oceanheight.h"

using namespace onyxtouch;

OceanHeight::OceanHeight(Ocean::Type type, const Vec2 &size)
	: type(type), totalTime(0) {
	(void)size;

	int N = 128;
	float L = 16.0f;

	// The ocean needs to be created so that:
	//  1. each vertex corresponds to point on the main Fourier band
	//  2. the width of the ocean equals the width specified in size
	// 1:
	scale = L / (float)N;

	// 2 (0.9999999f to round up):
	vertsW = (int)(size.x / scale + 1.9999999f);
	vertsH = (int)(size.y / scale + 1.9999999f);

	offt = new OceanFFT(type, N, L, 0, Vec2(5, 10));
}

OceanHeight::~OceanHeight() {
	delete offt;
}

OceanHeight::Error OceanHeight::initialize() {
	offt->initialize();

	// Create the texture
	GL_ASSERT(glGenTextures(1, &textureId));
    GL_ASSERT(glBindTexture(GL_TEXTURE_2D, textureId));
    GL_ASSERT(glPixelStorei(GL_UNPACK_ALIGNMENT, 1));
    GL_ASSERT(glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR));
    GL_ASSERT(glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR));

	return SUCCESS;
}

void OceanHeight::terminate() {
	offt->terminate();

	glDeleteTextures(1, &textureId);
}

void OceanHeight::update(float elapsedTime) {
	totalTime += elapsedTime;
	offt->generateHeightField(0.0f, totalTime * 0.001f);
}