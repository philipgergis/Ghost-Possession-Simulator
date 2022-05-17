Shader "Custom/GhostShader"
{
    Properties
    {
        _Color ("Rim Color", Color) = (1,1,1,1)
        _Power ("Rim Power", float) = 5.0
        _Strength ("Rim Strength", float) = 0.05
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" "ForceNoShadowCasting"="True" "IgnoreProjector"="True"}
        Pass
        {
            ZWrite On
            ColorMask 0
        }

        Tags { "RenderType"="Transparent" "Queue"="Transparent" "ForceNoShadowCasting"="True" "IgnoreProjector"="True"}
        LOD 100
        Blend SrcAlpha One
        Cull Back
        ZWrite Off

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float3 viewDir;
        };

        float4 _Color;
        float _Power;
        float _Strength;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float rim = 1.0 - saturate( dot(IN.viewDir, o.Normal) );
            rim = saturate(pow(rim, _Power) * _Strength);
            o.Albedo = _Color.rgb * rim;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
