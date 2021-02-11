using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BezierQuadratic : MonoBehaviour {

    public Transform positionA;
    public Transform positionB;
    public Transform handle;

    public float percent = 0;
    public int curveResolution = 10;

    [Header("Tween Stuff")]
    [Tooltip("How long the tween should take, in seconds.")]
    [Range(.1f, 10)] public float tweenLength = 3;
    public AnimationCurve tweenSpeed;
    /// <summary>
    /// This value counts up when the animation is playing.
    /// </summary>
    private float tweenTimer = 0;
    private bool isTweening = false;

    void Start()
    {
        
    }


    void Update() {

        if (isTweening) {
            tweenTimer += Time.deltaTime;
            float p = tweenTimer / tweenLength;
            percent = tweenSpeed.Evaluate(p);

            if (tweenTimer > tweenLength) isTweening = false;
        }

        transform.position = CalcPositionOnCurve(percent);
    }
    public void PlayTween() {
        tweenTimer = 0;
        isTweening = true;
    }

    private Vector3 CalcPositionOnCurve(float percent) {

        // pC = lerp between pA and handle

        Vector3 c = AnimMath.Lerp(positionA.position, handle.position, percent);
        Vector3 d = AnimMath.Lerp(handle.position, positionB.position, percent);

        Vector3 f = AnimMath.Lerp(c, d, percent);

        return f;
    }

    private void OnDrawGizmos() {

        Vector3 p1 = positionA.position;

        for(int i = 1; i < curveResolution; i++) {

            float p = i / (float)curveResolution;

            Vector3 p2 = CalcPositionOnCurve(p);

            Gizmos.DrawLine(p1, p2);
            p1 = p2;
        }

        Gizmos.DrawLine(p1, positionB.position);
    }

}

[CustomEditor(typeof(BezierQuadratic))]
public class BezierQuadraticEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        if(GUILayout.Button("Play Tween")) {
            (target as BezierQuadratic).PlayTween();
        }
    }
}
