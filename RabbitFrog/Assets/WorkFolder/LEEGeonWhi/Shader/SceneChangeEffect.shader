Shader "Unlit/SceneChangeEffect"
{
    Properties{
        _MainTex("MainTex", 2D) = ""{}
        _t("t", Range (0.0, 1.0)) = 1.0
}

SubShader{
    Pass {
        CGPROGRAM

        #include "UnityCG.cginc"

        #pragma vertex vert_img
        #pragma fragment frag

        sampler2D _MainTex;
        float _t;

        fixed4 frag(v2f_img i) : COLOR 
        {
            fixed4 c = tex2D(_MainTex, i.uv);
        float Alpha = 1 - step(i.uv.x, _t);
            return c * Alpha;
        }
        ENDCG
    }
}
}