Shader "Unlit/Stencil/Outline-Mask"
{
    Properties
    {
        _Color ("Main Color", Color) = (1,1,1,1)
        [IntRange(0, 255)] _StencilRef ("Stencil Ref", Int) = 1
        [Enum(UnityEngine.Rendering.CompareFunction)] _ZTest("ZTest", Float) = 0
    }

    SubShader
    {
        Tags
        {
            "Queue" = "Transparent+1"
            "RenderType" = "Transparent"
        }

        Cull Off
        ColorMask 0
        ZTest [_ZTest]
        ZWrite Off
        
        Pass
        {
            Stencil
            {
                Ref [_StencilRef]
                Pass Replace
            }
        }
    }
}