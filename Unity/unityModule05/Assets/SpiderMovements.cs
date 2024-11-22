using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovements : MonoBehaviour
{

    [SerializeField] private Vector2 boxSize;
    [SerializeField] private Vector2 boxSize2;

    [SerializeField] private float castDistance2;
    [SerializeField] private float castDistance;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask roofLayer;

    private bool isTrigger = true;
    private float speed = 0.25f;


    public bool CheckGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckRoof()
    {
        if (Physics2D.BoxCast(transform.position, boxSize2, 0, transform.up, castDistance2, roofLayer))
        {
            return true;
        }
        else
        {
            return false;
        }

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position + transform.up * castDistance2, boxSize2);
    }


        // Update is called once per frame
        void Update()
    {
        if (isTrigger)
            SpiderDown();
        else if (!isTrigger)
            SpiderUp();
    }

    private void FixedUpdate()
    {
        if (CheckGrounded())
            isTrigger = false;
        if (CheckRoof())
            isTrigger = true;
    }

    private void SpiderUp()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void SpiderDown()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }


}
