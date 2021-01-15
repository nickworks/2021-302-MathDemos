using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDemo : MonoBehaviour
{

    public GameObject objectStart;
    public GameObject objectEnd;

    [Range(-1, 2)] public float percent = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DoTheLerp();

    }

    private void DoTheLerp()
    {
        transform.position = AnimMath.Lerp(
            objectStart.transform.position,
            objectEnd.transform.position,
            percent
        );
    }

    private void OnValidate()
    {
        DoTheLerp();
    }
}
