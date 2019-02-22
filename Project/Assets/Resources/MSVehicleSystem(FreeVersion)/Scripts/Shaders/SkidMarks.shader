Shader "MSVehicleSystem/SkidMarks" {
	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_NormalMap("NormalMap", 2D) = "bump" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _NormFactor ("Normal Strength", Range (0,1)) = 1
	}
	SubShader {
		Tags { 
			"Queue"="Transparent" 
    		"RenderType"="Transparent"
		}
		ZWrite Off
		Blend OneMinusDstColor One
		LOD 200
		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows alpha:fade
        #pragma target 3.0

		sampler2D _MainTex;
		sampler2D _NormalMap;
		half _NormFactor;

		struct Input {
			float2 uv_MainTex;
			float2 uv_NormalMap;
            float4 colorr: COLOR; 
		};

		half _Glossiness;
		half _Metallic;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex) * IN.colorr;
			o.Albedo = c.rgb * IN.colorr.rgb;;
			o.Normal = UnpackScaleNormal (tex2D (_NormalMap, IN.uv_NormalMap),_NormFactor);
			o.Metallic = _Metallic;
            o.Smoothness = _Glossiness; 
			o.Alpha = c.a * IN.colorr.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
