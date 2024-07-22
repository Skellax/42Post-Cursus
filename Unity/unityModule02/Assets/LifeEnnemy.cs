using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class LifeEnnemy : MonoBehaviour
{
    
    private float hp = 3;

    
    // Start is called before the first frame update

    
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        { 
            BulletScript bulletScript = other.GetComponent<BulletScript>();       
                Hited(bulletScript.GetDmg());
                Debug.Log("hitted life: " + hp);
                Destroy(other.gameObject);

    
        }
            
    }
    
    

    void Hited(float dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            Destroy(gameObject);
            Debug.Log("ennemy destroyed");
        }
    }
}
