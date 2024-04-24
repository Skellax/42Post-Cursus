using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaFall : MonoBehaviour
{
    public float fallLavaSpeed = 0.1f;
    Renderer render;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Time.time * fallLavaSpeed * -1;
        render.material.SetTextureOffset("_MainTex", new Vector3(0, speed, 0));
        
    }
}
