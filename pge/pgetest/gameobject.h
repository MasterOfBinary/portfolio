#pragma once

#include <pge.h>

using namespace pge;
using namespace pge::SceneObjects;

#define TYPE_SPACESHIP 1
#define TYPE_BRONZECOIN 2
#define TYPE_SILVERCOIN 3
#define TYPE_GOLDCOIN 4

class GameObjectBase
{
public:
	virtual void Initialize(pge::Engine *Engine) = 0;
	virtual void Created() = 0;
	virtual void BeforeUpdate() = 0;
	virtual void Update(float RelativeTime) = 0;
	virtual void Collision(GameObjectBase *Object) = 0;

	virtual int GetType() = 0;
	virtual void SetPosition(Vector3D Position) = 0;
	virtual Vector3D GetPosition() = 0;
};

class SpecialObject : public GameObjectBase
{
public:
	SpecialObject(Terrain *Terrain);
	virtual void Initialize(Engine *Engine);
	virtual void Created();
	virtual void BeforeUpdate();
	virtual void Update(float RelativeTime);
	virtual void Collision(GameObjectBase *Object);

	virtual int GetType() = 0;
	virtual void SetPosition(Vector3D Position);
	virtual Vector3D GetPosition();

	virtual Mesh *GetMesh();
	BoundingSphere *GetBoundingSphere();
protected:
	void RandomizePosition();

	Engine *m_Engine;
	Terrain *m_Terrain;
	Random m_Random;
	Vector3D m_Position;

	float m_RotY;

	Mesh *m_Mesh;
};

class Coin : public SpecialObject
{
public:
	Coin(Terrain *Terrain);
	void Initialize(Engine *Engine);
};

class BronzeCoin : public Coin
{
public:
	BronzeCoin(Terrain *Terrain);
	void Initialize(Engine *Engine);
	void Created();
	int GetType();
};

class SilverCoin : public Coin
{
public:
	SilverCoin(Terrain *Terrain);
	void Initialize(Engine *Engine);
	void Created();
	int GetType();
};

class GoldCoin : public Coin
{
public:
	GoldCoin(Terrain *Terrain);
	void Initialize(Engine *Engine);
	void Created();
	int GetType();
};

class SpaceShip : public GameObjectBase
{
public:
	SpaceShip(Terrain *Terrain, Vector3D Position);
	virtual void Initialize(Engine *Engine);
	virtual void Created();
	virtual void BeforeUpdate();
	virtual void Update(float RelativeTime);
	virtual void Collision(GameObjectBase *Object);

	virtual int GetType();
	virtual void SetPosition(Vector3D Position);
	virtual Vector3D GetPosition();
	virtual void SetRotationY(float Rotation);
	virtual Camera *GetCamera();

	void TurnLeft();
	void TurnRight();
	void MoveForward();
	void MoveBackward();
	void Brake();

	Mesh *GetMesh();
	BoundingSphere *GetBoundingSphere();
	int GetSpeed(); // Current speed in km/h
	int GetPoints();
protected:
	void UpdateCamera();
	void FollowTerrain();

	Engine *m_Engine;
	Terrain *m_Terrain;
	Camera *m_Camera;

	Vector3D m_Position;

	int m_Points;

	bool m_Moving;
	bool m_Turning;

	float m_Speed;
	float m_MaxSpeed;
	float m_MaxBank;
	float m_Acceleration;
	float m_RelativeTime;

	int *m_KPH;
	int m_NumKPH;
	int m_NextKPH;

	float m_RotY;
	float m_RotZ;
	Quaternion m_QuatY;
	Quaternion m_QuatZ;

	Mesh *m_Mesh;
};

class UserShip1 : public SpaceShip
{
public:
	UserShip1(SceneObjects::Terrain *Terrain, Vector3D Position);
	void Created();
	void Update(float RelativeTime);
};

class UserShip2 : public SpaceShip
{
public:
	UserShip2(SceneObjects::Terrain *Terrain, Vector3D Position);
	void Created();
	void Update(float RelativeTime);
};

class UserShip3 : public SpaceShip
{
public:
	UserShip3(SceneObjects::Terrain *Terrain, Vector3D Position);
	void Created();
	void Update(float RelativeTime);
};

class UserShip4 : public SpaceShip
{
public:
	UserShip4(SceneObjects::Terrain *Terrain, Vector3D Position);
	void Created();
	void Update(float RelativeTime);
};