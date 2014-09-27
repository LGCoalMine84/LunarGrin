Shader "Test/3b - Specular Pixel"
{
	Properties
	{
		_Color( "Color", Color ) = ( 1.0, 1.0, 1.0, 1.0 )
		_SpecColor( "Specular Color", Color ) = ( 1.0, 1.0, 1.0, 1.0 )
		_Shininess( "Shininess", Range( 1.0, 15.0 ) ) = 10.0
	}
	
	SubShader
	{
		Pass
		{
			tags { "LightMode" = "ForwardBase" }
		
			CGPROGRAM
			
			#pragma vertex vert
			#pragma fragment frag
			
			// User defined variables.
			uniform float4 _Color;
			uniform float4 _SpecColor;
			uniform float _Shininess;
			
			// Unity defined variables.
			uniform float4 _LightColor0;
			
			// Unity 3.5 and below. Already defined in 4.0.
			//float4x4 _Object2World;
			//float4x4 _World2Object;
			//float4 _WorldSpaceLightPos0;
			
			// Base input structs.
			struct vertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};
			
			struct vertexOutput
			{
				float4 pos : SV_POSITION;
				float4 posWorld : TEXCOORD0;
				float3 normalDir : TEXCOORD1;
			};
			
			// Vertex function.
			vertexOutput vert( vertexInput v )
			{
				vertexOutput o;
				
				o.posWorld = mul( _Object2World, v.vertex );
				o.normalDir = normalize( mul( float4( v.normal, 0.0 ), _World2Object ).xyz );
				o.pos = mul( UNITY_MATRIX_MVP, v.vertex );
				
				return o;
			}
			
			// Fragment function.
			float4 frag( vertexOutput i ) : COLOR
			{
				// Vectors.
				float3 normalDirection = i.normalDir;
				float3 viewDirection = normalize( _WorldSpaceCameraPos.xyz - i.posWorld.xyz );
				
				// Lighting.
				float atten = 1.0;
				float3 lightDirection = normalize( _WorldSpaceLightPos0.xyz );
				float3 diffuseReflection = atten * _LightColor0.xyz * max( 0.0, dot( normalDirection, lightDirection ) );
				float3 specularReflection = atten * _SpecColor.rgb * max( 0.0, dot( normalDirection, lightDirection ) ) * 
											pow( max( 0.0, dot( reflect( -lightDirection, normalDirection ), viewDirection ) ), _Shininess );
				float3 lightFinal = diffuseReflection + specularReflection + UNITY_LIGHTMODEL_AMBIENT;
				
				return float4( lightFinal * _Color.rgb, 1.0 );
			}
			
			ENDCG
		}
	}
	
	fallback "Diffuse"
}
