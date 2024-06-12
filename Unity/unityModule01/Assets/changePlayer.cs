using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class changePlayer : MonoBehaviour
{
    public GameObject John;
    public GameObject Thomas;

    public GameObject Claire;

    private int input = 1;

    
    

    void switchPlayer()
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
        if (John!= null && Thomas != null && Claire != null)
        {
            switchPlayer();
            if (input == 1 && Claire.GetComponent<MovePlayer>().Isgrounded && John.GetComponent<MovePlayer>().Isgrounded)
            {
                Thomas.GetComponent<MovePlayer>().SetControl(true);
                Claire.GetComponent<MovePlayer>().SetControl(false);
                John.GetComponent<MovePlayer>().SetControl(false);
            }
            else if (input == 2 && Thomas.GetComponent<MovePlayer>().Isgrounded && John.GetComponent<MovePlayer>().Isgrounded)
            {
                Thomas.GetComponent<MovePlayer>().SetControl(false);
                Claire.GetComponent<MovePlayer>().SetControl(true);
                John.GetComponent<MovePlayer>().SetControl(false);
            }
            else if (input == 3 && Thomas.GetComponent<MovePlayer>().Isgrounded && Claire.GetComponent<MovePlayer>().Isgrounded)
            {
                Thomas.GetComponent<MovePlayer>().SetControl(false);
                Claire.GetComponent<MovePlayer>().SetControl(false);
                John.GetComponent<MovePlayer>().SetControl(true);
            }
        }       
    }
}
