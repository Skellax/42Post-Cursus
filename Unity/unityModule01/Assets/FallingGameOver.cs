using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingGameOver : MonoBehaviour
{
    public GameObject Thomas;
    public GameObject John;
    public GameObject Claire;

    // Update is called once per frame
    void Update()
    {
        if (Thomas != null && Thomas.transform != null && Thomas.transform.position.y < -5)
        {
            Destroy(Thomas);
            Thomas = null; 
        }
        if (John != null && John.transform != null && John.transform.position.y < -5)
        {
            Destroy(John);
            John = null; 
        }
        if (Claire != null && Claire.transform != null && Claire.transform.position.y < -5)
        {
            Destroy(Claire);
            Claire = null;
        }
    }
}
