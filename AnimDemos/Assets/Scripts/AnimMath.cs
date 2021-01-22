using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimMath
{
    public static float Lerp(float min, float max, float p, bool allowExtrapolation = true) {
        if (!allowExtrapolation) {
            if (p < 0) return min;
            if (p > 1) return max;
        }
        return (max - min) * p + min;
    }
    public static Vector3 Lerp(Vector3 min, Vector3 max, float p, bool allowExtrapolation = true) {
        if (!allowExtrapolation) {
            if (p < 0) return min;
            if (p > 1) return max;
        }
        return (max - min) * p + min;
    }

    public static float Slide(float current, float target, float percentLeftAfter1Second)
    {
        float p = 1 - Mathf.Pow(percentLeftAfter1Second, Time.deltaTime);
        return AnimMath.Lerp(current, target, p);
    }
    public static Vector3 Slide(Vector3 current, Vector3 target, float percentLeftAfter1Second)
    {
        float p = 1 - Mathf.Pow(percentLeftAfter1Second, Time.deltaTime);
        return AnimMath.Lerp(current, target, p);
    }

    public static Vector3 SpotOnCircleXZ(float radius, float currentAngle)
    {
        Vector3 offset = new Vector3();
        offset.x = Mathf.Sin(currentAngle) * radius;
        offset.z = Mathf.Cos(currentAngle) * radius;
        return offset;
    }
}
