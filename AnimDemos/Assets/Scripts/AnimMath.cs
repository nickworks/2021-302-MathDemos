using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimMath
{
    public static float Lerp(float min, float max, float p, bool allowExtrapolation = true)
    {
        if (!allowExtrapolation)
        {
            if (p < 0) p = 0;
            if (p > 1) p = 1;
        }

        return (max - min) * p + min;
    }
    public static Vector3 Lerp(Vector3 min, Vector3 max, float p, bool allowExtrapolation = true)
    {
        if (!allowExtrapolation)
        {
            if (p < 0) p = 0;
            if (p > 1) p = 1;
        }

        return (max - min) * p + min;

        //float x = Lerp(min.x, max.x, p);
        //float y = Lerp(min.y, max.y, p);
        //float z = Lerp(min.z, max.z, p);
        //return new Vector3(x, y, z);
    }
}
