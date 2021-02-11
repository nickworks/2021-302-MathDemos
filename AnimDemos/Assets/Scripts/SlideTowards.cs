using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideTowards : MonoBehaviour {
    
    public Transform target;

    private Camera cam;

    private void Start() {
        cam = GetComponentInChildren<Camera>();
    }

    void Update() {
        
        // slides the position towards the target:
        transform.position = AnimMath.Slide(transform.position, target.position, .01f);

        // ease camera rotation to look at the target:

        // get vector to target:
        Vector3 vectorToTarget = target.position - cam.transform.position;

        // create the desired rotation:
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);

        // set camera to ease toward the target rotation:
        cam.transform.rotation = AnimMath.Slide(cam.transform.rotation, targetRotation, .05f);


    }
}
