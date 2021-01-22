using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideTowards : MonoBehaviour {
    
    public Transform target;

    void Update() {
        transform.position = AnimMath.Slide(transform.position, target.position, .01f);
    }
}
