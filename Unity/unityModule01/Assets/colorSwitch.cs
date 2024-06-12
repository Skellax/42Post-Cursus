using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorSwitch : MonoBehaviour
{
    public GameObject playerTriggered;
    public GameObject wall;

    public GameObject button;

    public Renderer r_wall;

    public Material material;

    public int indexLayer;

    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTriggered.tag))
        {
            wall.layer = indexLayer;
            r_wall.material = material;
            button.transform.localScale = new Vector3(button.transform.localScale.x, 0, button.transform.localScale.z);
        }
    }

    void OnTriggerExit(Collider other)
    {
        button.transform.localScale = new Vector3(button.transform.localScale.x, 0.15f, button.transform.localScale.z);
    }

}
