// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

/*Shader "Outlined/Custom Camera Independent" {
	Properties{
		_Color("Main Color", Color) = (.5,.5,.5,1)
		_OutlineColor("Outline Color", Color) = (255,255,255,1)
		_Outline2("Outline width", Range(0, 1)) = .19
		_MainTex("Base (RGB)", 2D) = "white" { }
	}

		CGINCLUDE
#include "UnityCG.cginc"

		struct appdata {
		float4 vertex : POSITION;
		float3 normal : NORMAL;
	};

	struct v2f {
		float4 pos : POSITION;
		float4 color : COLOR;
	};

	uniform float _Outline2;
	uniform float4 _OutlineColor;

	v2f vert(appdata v) {
		// just make a copy of incoming vertex data but scaled according to normal direction
		v2f o;

		//Camera position in world
		float3 targetPos = _WorldSpaceCameraPos;

		//Object position in world
		float3 objectPos = mul(unity_ObjectToWorld, v.vertex).xyz;

		//Vertex offset from center of the object
		float3 offset = v.vertex.xyz;

		//Distance from the object to the camera
		float dist = distance(objectPos, targetPos + offset);

		//Forward vector of the camera
		float3 viewDir = UNITY_MATRIX_IT_MV[2].xyz;

		//Vector between vertex and offseted camera pos
		float3 distVec = objectPos - (targetPos + offset);

		//Angle between two vectors
		float angle = distVec - distVec;
		//float angle = atan2(normalize(cross(distVec,viewDir)), dot(distVec,viewDir));

		//Real distance (to the plane 90 degrees to camera forward and object)
		float finalDist = dist * cos(degrees(angle));

		//v.vertex *= ( 2 );
		v.vertex *= finalDist * _Outline2;

		//v.vertex *= -1;

		o.pos = UnityObjectToClipPos(v.vertex);

		o.color = _OutlineColor;
		return o;
	}
	ENDCG

		SubShader{
		//Tags {"Queue" = "Geometry+100" }
CGPROGRAM
#pragma surface surf Lambert

sampler2D _MainTex;
fixed4 _Color;

struct Input {
	float2 uv_MainTex;
};

void surf(Input IN, inout SurfaceOutput o) {
	fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
	o.Albedo = c.rgb;
	o.Alpha = c.a;
}
ENDCG

// note that a vertex shader is specified here but its using the one above
Pass {
	Name "OUTLINE"
	Tags { "LightMode" = "Always" }
	Cull Front
	ZWrite On
	ColorMask RGB
	Blend SrcAlpha OneMinusSrcAlpha
	//Offset 50,50

	CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag
	half4 frag(v2f i) :COLOR { return i.color; }
	ENDCG
}
	}

		SubShader{
	CGPROGRAM
	#pragma surface surf Lambert

	sampler2D _MainTex;
	fixed4 _Color;

	struct Input {
		float2 uv_MainTex;
	};

	void surf(Input IN, inout SurfaceOutput o) {
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		o.Albedo = c.rgb;
		o.Alpha = c.a;
	}
	ENDCG

			Pass {
				Name "OUTLINE"
				Tags { "LightMode" = "Always" }
				Cull Front
				ZWrite On
				ColorMask RGB
				Blend SrcAlpha OneMinusSrcAlpha

				CGPROGRAM
				#pragma vertex vert
				#pragma exclude_renderers gles xbox360 ps3
				ENDCG
				SetTexture[_MainTex] { combine primary }
			}
}

Fallback "Diffuse"
}
*/
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Outlined/Custom Constant Width" {
	Properties{
		_Color("Main Color", Color) = (.5,.5,.5,1)
		_OutlineColor("Outline Color", Color) = (255, 255, 255, 1)
		_Outline("Outline width", Range(0, 1)) = 1
		_Limiter("Outline width limiter", Range(0, 5)) = 1.05
		_MainTex("Base (RGB)", 2D) = "white" { }
	}

		CGINCLUDE
#include "UnityCG.cginc"

		struct appdata {
		float4 vertex : POSITION;
		float3 normal : NORMAL;
	};

	struct v2f {
		float4 pos : POSITION;
		float4 color : COLOR;
	};

	uniform float _Outline;
	uniform float _Limiter;
	uniform float4 _OutlineColor;

	v2f vert(appdata v) {

		v2f o;

		//Original concept of using FOV
		//float t = unity_CameraProjection._m11;
		//const float Rad2Deg = 180 / UNITY_PI;
		//float fov = atan(1.0f / t ) * 2.0 * Rad2Deg;

		//if(fov < _Limiter){
		//	fov = _Limiter;
		//}

		float multiplier = unity_OrthoParams.x * 0.1;

		if (multiplier < _Limiter) {
			multiplier = _Limiter;
		}

		v.vertex *= _Outline * multiplier;

		o.pos = UnityObjectToClipPos(v.vertex);

		o.color = _OutlineColor;
		return o;
	}
	ENDCG

		SubShader{
		//Tags {"Queue" = "Geometry+100" }
CGPROGRAM
#pragma surface surf Lambert

sampler2D _MainTex;
fixed4 _Color;

struct Input {
	float2 uv_MainTex;
};

void surf(Input IN, inout SurfaceOutput o) {
	fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
	o.Albedo = c.rgb;
	o.Alpha = c.a;
}
ENDCG

// note that a vertex shader is specified here but its using the one above
Pass {
	Name "OUTLINE"
	Tags { "LightMode" = "Always" }
	Cull Front
	ZWrite On
	ColorMask RGB
	Blend SrcAlpha OneMinusSrcAlpha
	//Offset 50,50

	CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag
	half4 frag(v2f i) :COLOR { return i.color; }
	ENDCG
}
	}

		SubShader{
	CGPROGRAM
	#pragma surface surf Lambert

	sampler2D _MainTex;
	fixed4 _Color;

	struct Input {
		float2 uv_MainTex;
	};

	void surf(Input IN, inout SurfaceOutput o) {
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		o.Albedo = c.rgb;
		o.Alpha = c.a;
	}
	ENDCG

			Pass {
				Name "OUTLINE"
				Tags { "LightMode" = "Always" }
				Cull Front
				ZWrite On
				ColorMask RGB
				Blend SrcAlpha OneMinusSrcAlpha

				CGPROGRAM
				#pragma vertex vert
				#pragma exclude_renderers gles xbox360 ps3
				ENDCG
				SetTexture[_MainTex] { combine primary }
			}
}

Fallback "Diffuse"
}