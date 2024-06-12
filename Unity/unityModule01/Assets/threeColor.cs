using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class threeColor : MonoBehaviour
{
    public GameObject platform;
    public Renderer r_platform;

    public Material colorDefault;
    public Material colorSecondary; 

    public Material colorThird;   

    public int timer;

    public int indexLayer1;
    public int indexLayer2;

    public int indexLayer3;

    private int isDefaultColor = 1;
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
            if (isDefaultColor == 1)
            {
                platform.layer = indexLayer1;
                r_platform.material = colorSecondary;
                isDefaultColor = 2;

            }
            else if (isDefaultColor == 2)
            {
                platform.layer = indexLayer2;
                r_platform.material = colorThird;
                isDefaultColor = 3;
            }
            else
            {
                platform.layer = indexLayer3;
                r_platform.material = colorDefault;
                isDefaultColor = 1;
            }
        }
    }
}
