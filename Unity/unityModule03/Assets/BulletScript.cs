using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private GameObject target;
    private Rigidbody2D rb;


   
    public float speed = 5.0f;

    private float dmg;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = FindClosestEnnemy();
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * speed * Time.deltaTime;
            float rot = Mathf.Atan2(-direction.x, -direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot);
        }
        
    }

    GameObject FindClosestEnnemy()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag("ennemy");
        GameObject closestEnnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject ennemy in ennemies)
        {
            float distance = Vector3.Distance(transform.position, ennemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnnemy = ennemy;
            }
        }
        return closestEnnemy;
    }


    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            rb.velocity = direction.normalized * speed;
        }
        
        
    }

    public void SetDmg(float dmg)
    {
        this.dmg = dmg;
    }

    public float GetDmg()
    {
        return dmg;
    }
}
