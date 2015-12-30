//---------------------------------------------------------------------------
// fft.cpp
// Private, this file is not to be distributed
// OnyxTouch Ocean Rendering Library
// Copyright (c) 2013 ePeriod Software, All Rights Reserved
//---------------------------------------------------------------------------

#include "stdafx.h"
#include "fft.h"
#include <acml.h>

using namespace onyxtouch;

//
// Constructors and destructors
//

FFT::FFT(int size) : size(size) {
	// TODO pick the best fft type

	// Initialize communication work array
	fftComm = new otcomplex[size * size + 10 * size];
}

FFT::~FFT() {
	delete []fftComm;
}

//
// Initialization and termination
//
	
FFT::Error FFT::initialize() {
	return SUCCESS;
}

void FFT::terminate() { }

//
// Execution
//
	
FFT::Error FFT::execute(otcomplex *data) {
	__int64 info;

	// otcomplex is compatible with ::complex
	cfft2d(1, size, size, (::complex *)data, (::complex *)fftComm, &info);
	if (info != 0)
		return FFT_ERROR;

	return SUCCESS;
}