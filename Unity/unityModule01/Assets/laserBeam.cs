using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class laserBeam : MonoBehaviour
{
    private string target = "Thomas";
    public LineRenderer beam;

    public float time;

    void Start()
    {
        StartCoroutine(colorBeam());
    }

    IEnumerator colorBeam()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            beam.startColor = Color.blue;
            beam.endColor = Color.cyan;
            target = "Claire";
            yield return new WaitForSeconds(time);
            beam.startColor = Color.yellow;
            beam.endColor = Color.white;
            target = "John";
            yield return new WaitForSeconds(time);
            beam.startColor = Color.red;
            beam.endColor  = Color.magenta;
            target = "Thomas";
        }
        
    }

    // Start is called before the first frame update 
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(target))
        {
            Destroy(other.gameObject);
        }
    }
}
