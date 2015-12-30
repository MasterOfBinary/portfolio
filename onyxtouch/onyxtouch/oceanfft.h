//---------------------------------------------------------------------------
// oceanfft.h
// Private, this file is not to be distributed
// OnyxTouch Ocean Rendering Library
// Copyright (c) 2013 ePeriod Software, All Rights Reserved
//---------------------------------------------------------------------------

#ifndef _OCEANFFT_H_
#define _OCEANFFT_H_

#include "ocean.h"
#include "types.h"
#include "fft.h"
#include "complex.h"

#define OUTPUT_TYPE_HEIGHT 0x1
#define OUTPUT_TYPE_NORM 0x2
#define OUTPUT_TYPE_DISP 0x4

namespace onyxtouch {

struct TessendorfData {
	Vec2 k;
	otcomplex hTilde0, hTilde0conj;
	float dispersion;
};

class OceanFFT {
public:
	enum Error {
		SUCCESS
	};

	OceanFFT(Ocean::Type type, int N, float L, int outputTypes, const Vec2 &wind);
	~OceanFFT();

	Error initialize();
	void terminate();

	void generateHeightField(float minL, float t);

	inline Ocean::Type getType() {
		return type;
	}

	inline float *getOutput() {
		return output;
	}

	inline float getL() {
		return L;
	}

	inline unsigned int getN() {
		return N;
	}

	// Returns the amount of space between two points on the fft
	inline float getVertexScale() {
		return L / (float)N;
	}

protected:
	int N;
	float L;
	Vec2 wind;
	float g;
	
	Ocean::Type type;
	int outputTypes;
	const int outputSize;
	float *output;

	FFT *fft;
	void *oceanData; // Type-specific data

	// FFT inputs/outputs
	otcomplex *fftData, *fftDataX, *fftDataY;

	// Get rid of warning C4512 in VS
	OceanFFT &operator=(const OceanFFT &) { }
};

};

#endif // _OCEANFFT_H_