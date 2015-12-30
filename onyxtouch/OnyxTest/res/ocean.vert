// Inputs
attribute vec4 a_position; // Vertex Position (x, y, z, w)
attribute vec3 a_normal; // Normal vector

// Uniforms
uniform sampler2D u_oceanData; // Height map, normals, etc.
uniform mat4 u_worldViewProjectionMatrix; // Matrix to transform a position to clip space.
uniform mat4 u_inverseTransposeWorldViewMatrix; // Matrix to transform a normal to view space.
uniform float u_time; // Time

// Outputs
varying vec3 v_positionVector; // Position in view space
varying vec3 v_normalVector; // Normal vector in view space.

// Vertex Program
void main()
{
	vec4 pos = a_position;
	vec3 norm = a_normal;

	vec2 texPos = mod(a_position.xz * 8, 128);
	vec3 sample = texture2D(u_oceanData, texPos / 128);
	pos.y = sample.r;

    // Transform position to clip space
	gl_Position = u_worldViewProjectionMatrix * pos;
	v_positionVector = gl_Position;

	// Transform normal to view space
	mat3 inverseTransposeWorldViewMatrix = mat3(u_inverseTransposeWorldViewMatrix[0].xyz, u_inverseTransposeWorldViewMatrix[1].xyz, u_inverseTransposeWorldViewMatrix[2].xyz);
	norm = normalize(vec3(-sample.g, 1, -sample.b));
    v_normalVector = inverseTransposeWorldViewMatrix * norm;
}
