//---------------------------------------------------------------------------
// complex.h
// Private, this file is not to be distributed
// OnyxTouch Ocean Rendering Library
// Copyright (c) 2013 ePeriod Software, All Rights Reserved
//---------------------------------------------------------------------------
// In the debug configuration, this class is a lot faster than the
// std::complex class.
//---------------------------------------------------------------------------

#ifndef _COMPLEX_H_
#define _COMPLEX_H_

#include <cmath>
#include <random>

namespace onyxtouch {
	
// In debug mode, std::complex is unnecessarily slow and using it reduces
// frame rate a lot
#ifdef _DEBUG
#define DEFINE_CLASS_COMPLEX
#endif

#ifdef DEFINE_CLASS_COMPLEX

class Complex {
public:
	float re, im;

	inline Complex() {
		re = 0.0f;
		im = 0.0f;
	}

	inline Complex(float real, float imag) {
		this->re = real;
		this->im = imag;
	}

	inline Complex(const Complex &other) {
		re = other.re;
		im = other.im;
	}

	inline float real() {
		return re;
	}

	inline void real(float re) {
		this->re = re;
	}

	inline float imag() {
		return im;
	}

	inline void imag(float im) {
		this->im = im;
	}

	inline Complex operator+(const Complex &other) {
		return Complex(re + other.re, im + other.im);
	}

	inline Complex operator*(const Complex &other) {
		return Complex(re * other.re - im * other.im,
			re * other.im + im * other.re);
	}

	inline Complex operator*(const float &other) {
		return Complex(re * other, im * other);
	}
};

inline Complex exp(const Complex &in) {
	return Complex(cos(in.im), sin(in.im)) * ::exp(in.re);
}

inline Complex conj(const Complex &in) {
	return Complex(in.re, -in.im);
}

typedef onyxtouch::Complex otcomplex;

#else
#include <complex>

inline std::complex<float> conj(const std::complex<float> &in) {
	return std::complex<float>(in.real(), -in.imag());
}

typedef std::complex<float> otcomplex;
#endif

inline float realRand(float max = 1.0f) {
	float r = (float)rand() / RAND_MAX;
	return r * max;
}

inline otcomplex gaussRand() {
	float x1, x2, w;
	do {
		x1 = 2.f * realRand() - 1.f;
		x2 = 2.f * realRand() - 1.f;
		w = x1 * x1 + x2 * x2;
	} while (w >= 1.f);
	w = sqrt((-2.f * log(w)) / w);
	return otcomplex(x1 * w, x2 * w);
}

};

#endif // _COMPLEX_H_