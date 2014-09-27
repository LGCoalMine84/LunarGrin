//#region File Header

// File Name:           MantisShader.shader
// Author:              Andy Sanchez
// Creation Date:       9/3/2014   10:49 PM
//
// Copyrights:          Copyright 2014
//                      Lunar Grin, LLC.
//                      All rights reserved.

//#endregion

Shader "LunarGrin/ShipShader" 
{
	Properties 
	{ 
		_Color( "Main Color", Color ) = ( 1.0, 1.0, 1.0, 1.0 )
		//_SpecColor( "Specular Color", Color ) = ( 0.5, 0.5, 0.5, 1.0 )
		_MaskColor( "Mask Color", Color ) = ( 1.0, 1.0, 1.0, 1.0 )
		_SubMaskColor( "SubMask Color", Color ) = ( 1.0, 1.0, 1.0, 1.0 )
		_Shininess( "Shininess", Range( -10.0, 10.0 ) ) = 0.078125
		_BumpFactor( "Bump Factor", Range( 0.2, 10.0 ) ) = 1.0
		_MainTex( "Base (RGB) Gloss (A)", 2D ) = "white" { }
		_BumpMap( "Normal Map", 2D ) = "bump" { }
		_SpecMap( "Specular Map", 2D ) = "black" { }
		_GlowMap( "Glow Map", 2D ) = "black" { }
		_MaskMap( "Mask Map", 2D ) = "white" { }
		_SubMaskMap( "SubMask Map", 2D ) = "white" { }
	}
	
	SubShader 
	{
		Tags { "RenderType" = "Opaque" }
		
		//LOD 600
		
		CGPROGRAM
		
		#pragma surface surf Lambert
		
		uniform fixed4 _Color;
		uniform fixed4 _MaskColor;
		uniform fixed4 _SubMaskColor;
		uniform half _Shininess;
		uniform half _BumpFactor;
		uniform sampler2D _MainTex;
		uniform sampler2D _BumpMap;
		uniform sampler2D _SpecMap;
		uniform sampler2D _GlowMap;
		uniform sampler2D _MaskMap;
		uniform sampler2D _SubMaskMap;

		struct Input 
		{
			float2 uv_MainTex 	 : TEXCOORD0;
			float2 uv_BumpMap 	 : TEXCOORD1;
			float2 uv_SpecMap 	 : TEXCOORD2;
			float2 uv_GlowMap 	 : TEXCOORD3;
			float2 uv_MaskMap 	 : TEXCOORD4;
			float2 uv_SubMaskMap	 : TEXCOORD5;
		};

		void surf ( Input IN, inout SurfaceOutput o ) 
		{
			float4 diffuseTex = tex2D( _MainTex, IN.uv_MainTex );
			
			fixed4 colorMap = diffuseTex.rgba;

			float4 specularTex = tex2D( _SpecMap, IN.uv_SpecMap );
			o.Specular = _Shininess * specularTex.g;
			o.Gloss = specularTex.r;
			
			float4 tempTexture = tex2D( _BumpMap, IN.uv_BumpMap );
			float3 tempNormal = UnpackNormal( tempTexture );
			tempNormal.xy *= _BumpFactor;
			o.Normal = tempNormal;
			
			fixed4 maskTexture = tex2D( _MaskMap, IN.uv_MaskMap );
			fixed3 first = lerp( colorMap.rgb, 2.0 * maskTexture.a * _MaskColor.rgb, maskTexture.r );
			fixed3 second = lerp( first, 2.0 * maskTexture.a * _MaskColor.rgb, maskTexture.g );
			fixed3 third = lerp( second, 2.0 * maskTexture.a * _MaskColor.rgb, maskTexture.b );
			fixed3 finalMask = third;
			
			maskTexture = tex2D( _SubMaskMap, IN.uv_SubMaskMap );
			first = lerp( finalMask, 2.0 * maskTexture.a * _SubMaskColor.rgb, maskTexture.r );
			second = lerp( first, 2.0 * maskTexture.a * _SubMaskColor.rgb, maskTexture.g );
			third = lerp( second, 2.0 * maskTexture.a * _SubMaskColor.rgb, maskTexture.b );
			fixed3 finalMask2 = third;
			
			//finalMask = saturate( finalMask );
			finalMask2 = saturate( finalMask2 ) + UNITY_LIGHTMODEL_AMBIENT;
			
			//o.Albedo = finalMask;
			//o.Albedo *= finalMask2;
			o.Albedo = ( ( finalMask2 ) * colorMap.rgb );
			o.Alpha = diffuseTex.a * _Color.a;
			//o.Alpha = diffuseTex.a * _Color.a;
		}
		
		ENDCG
	}
	
	FallBack "Lambert"
}
