using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed = 4.0f;
    public string tagName;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed *Time.deltaTime);
        
    }

    void  OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (!other.CompareTag(tag))
        {
            Destroy(gameObject);
        }
    }
}
