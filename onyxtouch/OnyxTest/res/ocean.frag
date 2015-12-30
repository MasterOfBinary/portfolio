#ifdef OPENGL_ES
precision highp float;
#endif

// Inputs
varying vec3 v_positionVector; // Position in view space
varying vec3 v_normalVector; // Normal vector in view space
varying vec3 v_lightDirection; // Direction of light in tangent space

// Uniforms
uniform sampler2D u_perPixelData; // Small normal map for per-pixel normals
uniform vec4 u_diffuseColor; // Diffuse color
uniform vec3 u_ambientColor; // Ambient color
uniform vec3 u_lightColor; // Light color
uniform vec3 u_lightDirection; // Light direction

// Uniforms related to waves (for per-pixel normals)
uniform float u_time; // Current time in seconds
uniform vec2 u_directions[15]; // Directions of the different waves
uniform float u_wavelengths[15]; // Wavelengths of the different waves
uniform float u_speeds[15]; // Speeds of the different waves

vec4 _baseColor;
vec3 _ambientColor;
vec3 _diffuseColor;

vec3 computeLighting(vec3 normalVector, vec3 lightDirection, float attenuation)
{
    // Ambient
    _ambientColor = _baseColor.rgb * u_ambientColor;

    // Diffuse
	float ddot = dot(normalVector, lightDirection);
    float diffuseIntensity = attenuation * ddot;
    diffuseIntensity = max(0.0, diffuseIntensity);
    _diffuseColor = u_lightColor * _baseColor.rgb * diffuseIntensity;
	
	return _ambientColor + _diffuseColor;
}

vec3 getLitPixel(vec3 normalVector)
{
    // Normalize the vectors.
    normalVector = normalize(normalVector);
    vec3 lightDirection = normalize(u_lightDirection);
    
    return computeLighting(normalVector, -lightDirection, 1.0);
}

// Fragment program
void main()
{
	_baseColor = u_diffuseColor;

	vec3 pos = v_positionVector.xyz;
	vec3 norm = normalize(v_normalVector);

	vec2 texPos = mod(pos.xz * 16, 64);
	vec3 sample = texture2D(u_perPixelData, texPos / 64);
	//norm += normalize(vec3(-sample.r, 1, -sample.g));
	norm = normalize(norm);

    // Light the pixel
    gl_FragColor.a = _baseColor.a;
    gl_FragColor.rgb = getLitPixel(norm);
}
