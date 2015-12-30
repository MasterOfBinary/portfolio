#include "OnyxTest.h"

using namespace onyxtouch;

// Declare our game instance
OnyxTest game;

OnyxTest::OnyxTest()
	: _scene(NULL), _ot(NULL), _ocean(NULL), _oceanNode(NULL)
{
}

void OnyxTest::initialize()
{
    // Create game scene
	_scene = Scene::create();

	// Create a camera
	Node *camNode = Node::create("camera");
	Camera *cam = Camera::createPerspective(45.0f, (float)getWidth() / (float)getHeight(), 0.25f, 100.0f);
	camNode->setCamera(cam);
	_scene->setActiveCamera(cam);
	cam->release();

	_scene->addNode(camNode);
	camNode->release();

	// Set camera position and rotation
	Matrix lookAt;
	Matrix::createLookAt(0, 3, -4, 0, 0, 10, 0, 0, 1, &lookAt);
	Quaternion rot;
	lookAt.getRotation(&rot);
	camNode->setRotation(rot);
	camNode->setTranslation(0, 3, -4);

	// Create the ocean
	_ot = new OnyxTouch(OnyxTouch::GAMEPLAY);
	GP_ASSERT(_ot->initialize() == OnyxTouch::SUCCESS);

	// Set up ocean
	_oceanNode = Node::create("ocean");
	GameplayParams params;
	params.oceanNode = _oceanNode;
	_ocean = new Ocean(_ot, Ocean::TESSENDORF, &params, Vec2(80, 80), Vec2(20, 5));
	GP_ASSERT(_ocean->initialize() == OnyxTouch::SUCCESS);

	_scene->addNode(_oceanNode);
	_oceanNode->release();

	// Set ocean position
	_oceanNode->setTranslation(0, 0, 37);
}

void OnyxTest::finalize()
{
	_ocean->terminate();
	_ot->terminate();
	SAFE_DELETE(_ocean);
	SAFE_DELETE(_ot);

    SAFE_RELEASE(_scene);
}

void OnyxTest::update(float elapsedTime)
{
	if (_ocean)
		_ocean->update(elapsedTime);
}

void OnyxTest::render(float elapsedTime)
{
    // Clear the color and depth buffers
    clear(CLEAR_COLOR_DEPTH, Vector4::zero(), 1.0f, 0);

    // Visit all the nodes in the scene for drawing
    _scene->visit(this, &OnyxTest::drawScene);
}

bool OnyxTest::drawScene(Node* node)
{
    // If the node visited contains a model, draw it
    Model* model = node->getModel(); 
    if (model)
    {
        model->draw();
    }
    return true;
}

void OnyxTest::keyEvent(Keyboard::KeyEvent evt, int key)
{
    if (evt == Keyboard::KEY_PRESS)
    {
        switch (key)
        {
        case Keyboard::KEY_ESCAPE:
            exit();
            break;
        }
    }
}

void OnyxTest::touchEvent(Touch::TouchEvent evt, int x, int y, unsigned int contactIndex)
{
    switch (evt)
    {
    case Touch::TOUCH_PRESS:
        break;
    case Touch::TOUCH_RELEASE:
        break;
    case Touch::TOUCH_MOVE:
        break;
    };
}
