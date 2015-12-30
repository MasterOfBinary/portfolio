//---------------------------------------------------------------------------
// onyxtouch.h
// OnyxTouch Ocean Rendering Library
// Copyright (c) 2013 ePeriod Software, All Rights Reserved
//---------------------------------------------------------------------------

#ifndef _ONYXTOUCH_H_
#define _ONYXTOUCH_H_

#include "exports.h"
#include "ocean.h"
#include "types.h"

namespace onyxtouch {

class ONYXTOUCH_API OnyxTouch {
public:
	enum Error {
		SUCCESS
	};

	enum Platform {
		GAMEPLAY
	};

	OnyxTouch(Platform platform);
	~OnyxTouch();

	Error initialize();
	void terminate();
	
	inline Platform getPlatform() {
		return platform;
	}

protected:
	OnyxTouch(const OnyxTouch &);
	OnyxTouch &operator=(const OnyxTouch &);

	const Platform platform;
};

}; // onyxtouch

#endif // _ONYXTOUCH_H_