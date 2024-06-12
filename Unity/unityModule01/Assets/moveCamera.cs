using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class moveCamera : MonoBehaviour
{
    public Transform Thomas;
    public Transform Claire;
    public Transform John;
    public float x = 5;
    public float y = 2;

    private int input = 1;
    // Start is called before the first frame update
    public void switchCam()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            input = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            input = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            input = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Thomas != null && Claire != null && John != null)
        {
            switchCam();
            if (input == 1)
            {
                if (Thomas.position.y > -1)
                {
                    transform.position = new Vector3(x, y + Thomas.position.y, Thomas.position.z);
                }
                else
                {
                    transform.position = new Vector3(x, -1, Thomas.position.z);
                }

            }
            else if (input == 2)
            {
                if (Claire.position.y > -1)
                {
                    transform.position = new Vector3(x, y + Claire.position.y, Claire.position.z);
                }
                else
                {
                    transform.position = new Vector3(x, -1, Claire.position.z);
                }
            }
            else if (input == 3)
            {
                if (John.position.y > -1)
                {
                    transform.position = new Vector3(x, y + John.position.y, John.position.z);
                }
                else
                {
                    transform.position = new Vector3(x, -1, John.position.z);
                }           
            }
        }       
    }
}
