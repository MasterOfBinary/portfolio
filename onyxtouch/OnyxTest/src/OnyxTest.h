#ifndef OnyxTest_H_
#define OnyxTest_H_

#include "gameplay.h"
#include <onyxtouch.h>

using namespace gameplay;

/**
 * Main game class.
 */
class OnyxTest: public Game
{
public:

    /**
     * Constructor.
     */
    OnyxTest();

    /**
     * @see Game::keyEvent
     */
	void keyEvent(Keyboard::KeyEvent evt, int key);
	
    /**
     * @see Game::touchEvent
     */
    void touchEvent(Touch::TouchEvent evt, int x, int y, unsigned int contactIndex);

protected:

    /**
     * @see Game::initialize
     */
    void initialize();

    /**
     * @see Game::finalize
     */
    void finalize();

    /**
     * @see Game::update
     */
    void update(float elapsedTime);

    /**
     * @see Game::render
     */
    void render(float elapsedTime);

private:

    /**
     * Draws the scene each frame.
     */
    bool drawScene(Node *node);

    Scene *_scene;
	
	// Data for OnyxTouch
	onyxtouch::OnyxTouch *_ot;
	onyxtouch::Ocean *_ocean;
	Node *_oceanNode;
};

#endif
