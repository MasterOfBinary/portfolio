//---------------------------------------------------------------------------
// ocean-impl.h
// Private, this file is not to be distributed
// OnyxTouch Ocean Rendering Library
// Copyright (c) 2013 ePeriod Software, All Rights Reserved
//---------------------------------------------------------------------------

#ifndef _OCEAN_IMPL_H_
#define _OCEAN_IMPL_H_

#include "exports.h"
#include "ocean.h"
#include "oceanheight.h"

namespace onyxtouch {

class Ocean::OceanImpl {
public:
	OceanImpl(OnyxTouch *ot, Ocean::Type type, const Vec2 &size)
		: ot(ot), oceanHeight(new OceanHeight(type, size)) { }
	virtual ~OceanImpl() {
		delete oceanHeight;
	}

	virtual Ocean::Error initialize() = 0;
	virtual void terminate() = 0;

	virtual void update(float elapsedTime) = 0;

	friend Ocean;

protected:
	const OnyxTouch *ot;
	
	OceanHeight *oceanHeight;
};

};

#endif // _OCEAN_IMPL_H_