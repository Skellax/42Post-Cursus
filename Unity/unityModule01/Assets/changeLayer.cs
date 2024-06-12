using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeLayer : MonoBehaviour
{

    public GameObject obj1;

    public Renderer obj2;
    public Material red;

    public Material blue;

    private bool isRed = true;

    void Start()
    {
        StartCoroutine(ChangeLayerAndColor());
    }
   
   
    IEnumerator ChangeLayerAndColor()
    {
        while (true)
        {
            yield return new WaitForSeconds(8);

            if (isRed)
            {
                obj1.layer = 7;
                obj2.material = blue;
                isRed = false;
            }
            else
            {
                obj1.layer = 11;
                obj2.material = red;
                isRed = true;
            }
        }
    }
}
