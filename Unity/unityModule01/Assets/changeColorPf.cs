using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColorPf : MonoBehaviour
{
    public GameObject platform;
    public Renderer r_platform;

    public Material colorDefault;
    public Material colorSecondary;    

    public int timer;

    public int indexLayer1;
    public int indexLayer2;

    private bool isDefaultColor = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changeColor());
    }

    IEnumerator changeColor()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            if (isDefaultColor)
            {
                platform.layer = indexLayer1;
                r_platform.material = colorSecondary;
                isDefaultColor = false;

            }
            else
            {
                platform.layer = indexLayer2;
                r_platform.material = colorDefault;
                isDefaultColor = true;
            }
        }
    }
}
