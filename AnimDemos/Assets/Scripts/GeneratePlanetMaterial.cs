using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlanetMaterial : MonoBehaviour
{

    public float zoom = 20;
    public int size = 512;
    private MeshRenderer mesh;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        MakeTexture();
    }

    void MakeTexture() {

        Texture2D texture = new Texture2D(size, size);

        Color[] pixels = texture.GetPixels();

        for(int y = 0; y < size; y++) {
            for(int x = 0; x < size; x++) {
                int i = x + y * size;

                float a = Mathf.PerlinNoise(x/zoom, y/zoom);

                if (a < .5f) {
                    pixels[i] = new Color(0, 0, 255); // blue
                } else {
                    pixels[i] = new Color(0, 255, 0); // green
                }
            }
        }
        texture.SetPixels(pixels);
        texture.Apply();

        mesh.material.SetTexture("_MainTex", texture);
    }

    
    void Update()
    {
        
    }
}
