//---------------------------------------------------------------------------
// params.h
// OnyxTouch Ocean Rendering Library
// Copyright (c) 2013 ePeriod Software, All Rights Reserved
//---------------------------------------------------------------------------
// Platform-specific parameters to be passed to the ocean.
//---------------------------------------------------------------------------

#ifndef _PARAMS_H_
#define _PARAMS_H_

//
// Classes required
//

// For gameplayParams
namespace gameplay {
	class Node;
};

namespace onyxtouch {

struct GameplayParams {
	gameplay::Node *oceanNode;
};

};

#endif