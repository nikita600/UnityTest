// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

// Unlit shader. Simplest possible colored shader.
// - no lighting
// - no lightmap support
// - no texture

Shader "Unlit/Stencil/Color-Outline" 
{
	
Properties 
{
    _Color ("Main Color", Color) = (1,1,1,1)
	_OutlineColor ("Outline Color", Color) = (0,0,0,0)
	_OutlineWidth ("Outline Width", Float) = 1
	
	_StencilRef ("Stencil Ref", Int) = 1
	_StencilOp ("Stencil Operation", Float) = 0
}

SubShader 
{
    Tags { "RenderType"="Opaque" }
    LOD 100
	
    Pass 
	{
		Cull Front
		ZTest Off

		Stencil
		{
			Ref [_StencilRef]
			Comp [_StencilOp]
		}
		
        CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
			
            struct appdata_t 
			{
                float4 vertex : POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f 
			{
                float4 vertex : SV_POSITION;
                UNITY_FOG_COORDS(0)
                UNITY_VERTEX_OUTPUT_STEREO
            };

			fixed _OutlineWidth;
            fixed4 _OutlineColor;

            v2f vert (appdata_t v)
            {
                v2f o;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				v.vertex.xyz *= _OutlineWidth;
                o.vertex = UnityObjectToClipPos(v.vertex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = _OutlineColor;
                UNITY_APPLY_FOG(i.fogCoord, col);
                UNITY_OPAQUE_ALPHA(col.a);
                return col;
            }
        ENDCG
    }
}

}
