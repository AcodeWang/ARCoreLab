Shader "Custom/PortalWindow"
{
	SubShader
    {

        ZWrite off
        ColorMask 0

        Stencil{
            Ref 1
            Comp Always
            Pass replace
        }

        Pass
        {

        }
    }
}

