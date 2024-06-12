using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPf : MonoBehaviour
{
    public Transform checkpoint1;
    public Transform checkpoint2;

    private Transform target;
    public float speed;
    // Start is called before the first frame update

    private float step;

    void Start()
    {
        target = checkpoint2;
    }

    void Update()
    {
        step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        
        if(Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            target = (target == checkpoint1) ? checkpoint2 : checkpoint1;
        }
    }
}
