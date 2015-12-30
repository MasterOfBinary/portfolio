//---------------------------------------------------------------------------
// ocean-gameplay.cpp
// Private, this file is not to be distributed
// OnyxTouch Ocean Rendering Library
// Copyright (c) 2013 ePeriod Software, All Rights Reserved
//---------------------------------------------------------------------------
// The ocean implementation for the gameplay platform.
//---------------------------------------------------------------------------

#include "stdafx.h"
#include "ocean-gameplay.h"
#include "ocean.h"
#include "ocean-impl.h"
#include "onyxtouch.h"

using namespace onyxtouch;
using namespace gameplay;

//
// Constructors and destructors
//

OceanGameplay::OceanGameplay(OnyxTouch *ot, Ocean::Type type, GameplayParams *params, const Vec2 &size, const Vec2 &wind)
	: OceanImpl(ot, type, size) {
	this->wind = Vector2(wind.x, wind.y);
	node = params->oceanNode;
}

OceanGameplay::~OceanGameplay() { }

//
// Initialization and termination
//

Ocean::Error OceanGameplay::initialize() {
	unsigned int vertsW = oceanHeight->getVertsW();
	unsigned int vertsH = oceanHeight->getVertsH();
	float scale = oceanHeight->getScale();

	// TODO size.width %= N == FALSE should give an error

	unsigned int numVerts = vertsW * vertsH;
	unsigned int vertsWDiv2 = vertsW / 2;
	unsigned int vertsHDiv2 = vertsH / 2;

	// Create water mesh

	int numElements = 2;
	VertexFormat::Element *elements = new VertexFormat::Element[numElements];
	elements[0].size = 4;
	elements[0].usage = VertexFormat::POSITION;
	elements[1].size = 3;
	elements[1].usage = VertexFormat::NORMAL;
	
	// Create the vertices
	float *vertices = new float[numVerts * 7]; // 4 positions and 3 normals
	for (unsigned int x = 0; x < vertsW; x++)
	{
		for (unsigned int y = 0; y < vertsH; y++)
		{
			int index = 7 * (x + y * vertsW);

			// Set positions
			vertices[index] = (float)((int)x - (int)vertsWDiv2) * scale;
			vertices[++index] = 0;
			vertices[++index] = (float)((int)y - (int)vertsHDiv2) * scale;
			vertices[++index] = 1;

			// Set normals
			vertices[++index] = 0;
			vertices[++index] = 1;
			vertices[++index] = 0;
		}
	}
	
	Mesh *mesh = Mesh::createMesh(VertexFormat(elements, numElements), numVerts);
	mesh->setVertexData(vertices);

	// Create indices
	unsigned int vertsW1 = vertsW - 1, vertsH1 = vertsH - 1;
	unsigned int indexCount = vertsW1 * vertsH1 * 6; // 6 points per quad (3 per each of two triangles)
	unsigned int *indices = new unsigned int[indexCount];

	for (unsigned int x = 0; x < vertsW1; x++)
	{
		unsigned int x1 = x + 1;
		for (unsigned int y = 0; y < vertsH1; y++)
		{
			unsigned int index = (x + y * vertsW1) * 6;
			unsigned int y1 = y + 1;

			// Triangle #1
			indices[index] = x1 + y1 * vertsW;
			indices[index + 1] = x1 + y * vertsW;
			indices[index + 2] = x + y * vertsW;

			// Triangle #2
			indices[index + 3] = x1 + y1 * vertsW;
			indices[index + 4] = x + y * vertsW;
			indices[index + 5] = x + y1 * vertsW;
		}
	}
	
	MeshPart *part = mesh->addPart(Mesh::TRIANGLES, Mesh::INDEX32, indexCount);
	part->setIndexData(indices, 0, indexCount);

	Model *model = Model::create(mesh);

	// Set material
	model->setMaterial("res/ocean.material");
	Material *mat = model->getMaterial();
    mat->getParameter("u_ambientColor")->setValue(Vector3(0.02f, 0.02f, 0.02f));
	mat->getParameter("u_lightColor")->setValue(Vector3(1, 1, 1));
	mat->getParameter("u_lightDirection")->setValue(Vector3(0.5f, -1, -0.2f));

	// Create ocean node
	node->setModel(model);
	model->release();

	// Create ocean height generator
	tex = Texture::Sampler::create(Texture::create(oceanHeight->getHeightData(), 128, 128, Texture::RGB));
	
	srand((unsigned int)time(NULL));

	return Ocean::SUCCESS;
}

void OceanGameplay::terminate() {
	SAFE_RELEASE(tex);
}

//
// Ocean rendering and updating
//

void OceanGameplay::update(float elapsedTime) {
	oceanHeight->update(elapsedTime);

	Material *mat = node->getModel()->getMaterial();
	mat->getParameter("u_oceanData")->setValue(tex);
}