using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class GenerateRingPath : MonoBehaviour
{
    [Range(10, 60)] public int num = 10;
    [Range(3, 20)] public float radius = 5;
    LineRenderer line;

    void Start() {
        GeneratePath();

    }
    void OnValidate() {
        GeneratePath();
    }

    private void GeneratePath() {
        line = GetComponent<LineRenderer>();

        // generate a bunch of points!
        float rad = 0;

        Vector3[] pts = new Vector3[num];

        for (int i = 0; i < num; i++) {
            pts[i] = new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad)) * radius;
            rad += Mathf.PI * 2 / num; // increase the angle
        }
        line.positionCount = num;
        line.SetPositions(pts);
    }

    void Update()
    {
        
    }
}
