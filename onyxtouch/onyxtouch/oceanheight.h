//---------------------------------------------------------------------------
// oceanheight.h
// Private, this file is not to be distributed
// OnyxTouch Ocean Rendering Library
// Copyright (c) 2013 ePeriod Software, All Rights Reserved
//---------------------------------------------------------------------------

#ifndef _OCEANHEIGHT_H_
#define _OCEANHEIGHT_H_

#include "types.h"
#include "ocean.h"
#include "oceanfft.h"
#pragma warning(push, 3)
#include "gameplay.h"
#pragma warning(pop)

namespace onyxtouch {

class OceanHeight {
public:
	enum Error {
		SUCCESS
	};

	// Type of ocean, and size in world units
	OceanHeight(Ocean::Type type, const Vec2 &size);
	~OceanHeight();

	Error initialize();
	void terminate();

	void update(float elapsedTime);

	inline GLuint getHeightData() {
		return textureId;
	}

	inline Ocean::Type getType() {
		return type;
	}

	inline unsigned int getVertsW() { return vertsW; }
	inline unsigned int getVertsH() { return vertsH; }
	inline float getScale() { return scale; }

protected:
	Ocean::Type type;
	OceanFFT *offt;

	float scale;
	unsigned int vertsW, vertsH;

	float totalTime;

	// Texture(s) used to store the heights
	GLuint textureId;
};

};

#endif // _OCEANHEIGHT_H_