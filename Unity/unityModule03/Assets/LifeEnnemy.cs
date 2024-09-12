using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class LifeEnnemy : MonoBehaviour
{
    
    public float hp;

    public int score;

    
    private SpriteRenderer sp;

    private Coroutine cor;
    private Color initialColor;

    private GenerateEnnemy spawn;

    private GestionScore points;

      
    // Start is called before the first frame update

    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        initialColor = sp.color;
        spawn = GetComponent<GenerateEnnemy>();
        points = GameObject.Find("GestionScore").GetComponent<GestionScore>();
    }

    public void SetSpawnManager(GenerateEnnemy spawnManager)
    {
        spawn = spawnManager;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        { 
            BulletScript bulletScript = other.GetComponent<BulletScript>();       
                Hited(bulletScript.GetDmg());
                cor = StartCoroutine(HitedColor());
                Destroy(other.gameObject);

    
        }
            
    }

    IEnumerator HitedColor()
    {
        sp.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sp.color = initialColor;
    }
    
    

    void Hited(float dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            spawn.DecreteEnnemies(1);
            if (points != null)
            {
                points.AddScore(score);
            }
            else
            {
                Debug.Log("points its not declared !");
            }
            
            Destroy(gameObject);
        }
    }
}
