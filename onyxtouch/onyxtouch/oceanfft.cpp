//---------------------------------------------------------------------------
// oceanfft.cpp
// Private, this file is not to be distributed
// OnyxTouch Ocean Rendering Library
// Copyright (c) 2013 ePeriod Software, All Rights Reserved
//---------------------------------------------------------------------------

#include "stdafx.h"
#include "oceanfft.h"

using namespace onyxtouch;

//
// Used by OCEAN_TYPE_TESSENDORF
// Tessendorf specific functions start with tes.
//

// Ph(k)
inline float tesPhillips(const Vec2 &k, const Vec2 &wind, float g) {
	Vec2 kunit = k, wunit = wind;

	float knorm = kunit.length();
	float wnorm = wunit.length();

	if (FLOAT_IS_ZERO(knorm)) return 0.0f;

	kunit.normalize(&kunit);
	wunit.normalize(&wunit);

	float kdotw = kunit.dot(wunit);
	float kdotw2 = kdotw * kdotw;

	float knorm2 = knorm * knorm;
	float knorm4 = knorm2 * knorm2;

	float L = wnorm * wnorm / g;
	float L2 = L * L;

	float damping = 0.001f;
	float l2 = L2 * damping * damping;

	float A = 0.0006f;

	float Ph = A * exp(-1.0f / (knorm2 * L2)) * kdotw2 / knorm4 * exp(-knorm2 * l2);

	return Ph;
}

// D(x, t)
inline float tesDispersion(const Vec2 &k, float g) {
	float w0 = 2.0f * M_PI / 200.0f;
	return floor(sqrt(g * sqrt(k.x * k.x + k.y * k.y)) / w0) * w0;
}

// H~0
inline otcomplex tesAmplitude(const Vec2 &k, const Vec2 &wind, float g) {
	otcomplex r = gaussRand();
	return r * sqrt(tesPhillips(k, wind, g) / 2.0f);
}

OceanFFT::OceanFFT(Ocean::Type type, int N, float L, int outputTypes, const Vec2 &wind)
	: type(type), N(N), L(L), outputTypes(outputTypes), wind(wind.x, wind.y), g(9.81f),
	outputSize(3) {
	fft = new FFT(N);
	output = new float[N * N * outputSize];
}

OceanFFT::~OceanFFT() {
	delete []output;
	delete fft;
}

OceanFFT::Error OceanFFT::initialize() {
	fft->initialize();
	
	TessendorfData *dat = new TessendorfData[N * N];

	Vec2 k;
	float n = (float)N;
	int index;

	for (int x = 0; x < N; x++) {
		k.x = 2.0f * M_PI * (x - n / 2.0f) / L;
		for (int y = 0; y < N; y++) {
			k.y = 2.0f * M_PI * (y - n / 2.0f) / L;

			index = x + N * y;
				
			dat[index].k = k;
			dat[index].hTilde0 = tesAmplitude(k, wind, g);
			dat[index].hTilde0conj = conj(tesAmplitude(Vec2(-k.x, -k.y), wind, g));
			dat[index].dispersion = tesDispersion(k, g);
		}
	}

	oceanData = dat;

	return SUCCESS;
}

void OceanFFT::terminate() {
	fft->terminate();

	delete []((TessendorfData *)oceanData);
}

void OceanFFT::generateHeightField(float minL, float t) {
	(void)minL;

	Vec2 k;
	int index;
	float len;
	TessendorfData *data = (TessendorfData *)oceanData;

	for (int x = 0; x < N; x++) {
		for (int y = 0; y < N; y++) {
			index = x + N * y; // Row major
			k = data[index].k;
			len = k.length();

			float omega = data[index].dispersion * t;

			float coso = cos(omega);
			float sino = sin(omega);

			otcomplex c0 = otcomplex(coso, sino);
			otcomplex c1 = otcomplex(coso, -sino);

			fftData[index] = data[index].hTilde0 * c0 + data[index].hTilde0conj * c1;

			// TODO Remove contributions below a certain value of L

			fftDataX[index] = fftData[index] * otcomplex(0, k.x);
			fftDataY[index] = fftData[index] * otcomplex(0, k.y);
			
			// TODO output displacements
		}
	}

	fft->execute(fftData);
	fft->execute(fftDataX);
	fft->execute(fftDataY);

	float sign;
	float signs[] = { 1.0f, -1.0f };
	index = 0;

	for (int x = 0; x < N; x++) {
		for (int y = 0; y < N; y++) {
			int indexh = x + N * y;
			index = indexh * outputSize;

			sign = signs[(x + y) & 1];

			output[index++] = fftData[indexh].real() * sign;
			output[index++] = fftDataX[indexh].real() * sign;
			output[index++] = fftDataY[indexh].real() * sign;

			// TODO displacements
		}
	}
}