Shader "Test/3a - Specular"
{
	Properties
	{
		_Color( "Color", Color ) = ( 1.0, 1.0, 1.0, 1.0 )
		_SpecColor( "Specular Color", Color ) = ( 1.0, 1.0, 1.0, 1.0 )
		_Shininess( "Shininess", Float ) = 10
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
				float4 col : COLOR;
			};
			
			// Vertex function.
			vertexOutput vert( vertexInput v )
			{
				vertexOutput o;
				
				// Vectors.
				float3 normalDirection = normalize( mul( float4( v.normal, 0.0 ), _World2Object ).xyz );
				float3 viewDirection = normalize( float3( float4( _WorldSpaceCameraPos.xyz, 1.0 ) - mul( _Object2World, v.vertex ).xyz ) );
				
				// Lighting.
				float atten = 1.0;
				float3 lightDirection = normalize( _WorldSpaceLightPos0.xyz );
				float3 diffuseReflection = atten * _LightColor0.xyz * max( 0.0, dot( normalDirection, lightDirection ) );
				float3 specularReflection = atten * _SpecColor.rgb * max( 0.0, dot( normalDirection, lightDirection ) ) * 
											pow( max( 0.0, dot( reflect( -lightDirection, normalDirection ), viewDirection ) ), _Shininess );
				float3 lightFinal = diffuseReflection + specularReflection + UNITY_LIGHTMODEL_AMBIENT;
				
				o.col = float4( lightFinal * _Color.rgb, 1.0 );
				o.pos = mul( UNITY_MATRIX_MVP, v.vertex );
				
				return o;
			}
			
			// Fragment function.
			float4 frag( vertexOutput i ) : COLOR
			{
				return i.col;
			}
			
			ENDCG
		}
	}
	
	fallback "Diffuse"
}
