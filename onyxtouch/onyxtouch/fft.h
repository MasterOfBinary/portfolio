//---------------------------------------------------------------------------
// fft.h
// Private, this file is not to be distributed
// OnyxTouch Ocean Rendering Library
// Copyright (c) 2013 ePeriod Software, All Rights Reserved
//---------------------------------------------------------------------------

#ifndef _FFT_H_
#define _FFT_H_

#include "complex.h"

namespace onyxtouch {

class FFT {
public:
	enum Error {
		SUCCESS,
		FFT_ERROR
	};

	FFT(int size);
	~FFT();
	
	Error initialize();
	void terminate();
	
	Error execute(otcomplex *data);
	
private:
	int size;

	// Communication work array for ACML
	otcomplex *fftComm;
};

};

#endif // _FFT_H_