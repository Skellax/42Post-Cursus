using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBall : MonoBehaviour
{
    public GameObject ball;
    private   float  spawnInterval = 2.0f;
    public Vector3 spwanOffest;
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (true)
        {
            Vector3 spawnPosition = transform.position + transform.TransformDirection(spwanOffest);
            yield return new WaitForSeconds(spawnInterval);
            var copy = Instantiate(ball, spawnPosition, transform.rotation);
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
            Destroy(copy, 3.0f);
        }      
    }
}
