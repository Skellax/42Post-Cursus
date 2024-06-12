using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;

public class switchWall : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;

    public Renderer r_wall1;
    public Renderer r_wall2;


    public GameObject button;

    public Material  red;
    public Material  blue;
    public Material yellow;



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Activate");
        if (other.tag == "John")
        {
            wall1.layer = 9;
            wall2.layer = 9;
            r_wall1.material = yellow;
            r_wall2.material = yellow;
            button.transform.localScale = new Vector3(button.transform.localScale.x, 0, button.transform.localScale.z);      
        }
        else if (other.tag == "Claire")
        {
            wall1.layer = 7;
            wall2.layer = 7;
            r_wall1.material = blue;
            r_wall2.material = blue;
            button.transform.localScale = new Vector3(button.transform.localScale.x, 0, button.transform.localScale.z);
        }
         else if (other.tag == "Thomas")
        {
            wall1.layer = 11;
            wall2.layer = 11;
            r_wall1.material = red;
            r_wall2.material = red;
            button.transform.localScale = new Vector3(button.transform.localScale.x, 0f, button.transform.localScale.z);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        button.transform.localScale = new Vector3(button.transform.localScale.x, 0.15f, button.transform.localScale.z);
    }

}
