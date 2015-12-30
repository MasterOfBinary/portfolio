//---------------------------------------------------------------------------
// ocean.h
// OnyxTouch Ocean Rendering Library
// Copyright (c) 2013 ePeriod Software, All Rights Reserved
//---------------------------------------------------------------------------

#ifndef _OCEAN_H_
#define _OCEAN_H_

#include "exports.h"
#include "types.h"
#include "params.h"

namespace onyxtouch {

class OnyxTouch;

class ONYXTOUCH_API Ocean {
public:
	enum Error {
		SUCCESS
	};

	enum Type {
		TESSENDORF
	};
	
	Ocean(OnyxTouch *ot, Type type, void *params, const Vec2 &size, const Vec2 &wind);
	~Ocean();

	Error initialize();
	void terminate();

	// Elapsed time is the number of milliseconds since last call to update
	void update(float elapsedTime);

	friend OnyxTouch;
	
	class OceanImpl;

protected:
	Ocean(const Ocean &);
	Ocean &operator=(const Ocean &);

	OceanImpl *impl;
};

}; // onyxtouch

#endif // _OCEAN_H_