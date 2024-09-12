using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Castle_Live : MonoBehaviour
{
    [SerializeField] private int hp = 5;
    private float maxhp = 5f;
    // Start is called before the first frame update

    public HealthBar healthbar;

    private GameEnd gameEnd;

    public void Start()
    {
        healthbar.SetMaxHealth(hp);

        gameEnd = GameObject.Find("GameEnd").GetComponent<GameEnd>();
    }

    public void Regene()
    {
        if (hp < maxhp)
        {
            hp++;
            healthbar.SetHealth(hp);
        }
    }

    public int GetHp()
    {
        return this.hp;
    }


     

    // Update is called once per frame

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ennemy"))
        {
            hp--;
            healthbar.SetHealth(hp);
            Destroy(other.gameObject);
            
            if (hp <= 0)
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag("ennemy");
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("bullet");
        GameObject[] turretsA = GameObject.FindGameObjectsWithTag("turret_A");
        GameObject[] turretsB = GameObject .FindGameObjectsWithTag("turret_B");
        GameObject[]turretsC = GameObject.FindGameObjectsWithTag("turret_C");
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("Spawn");
        GameObject canvas = GameObject.Find("Canvas");

        canvas.gameObject.SetActive(false);

        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }

        foreach (GameObject turretA in turretsA)
        {
            Destroy(turretA);
        }
         foreach (GameObject turretB in turretsB)
        {
            Destroy(turretB);
        }
         foreach (GameObject turretC in turretsC)
        {
            Destroy(turretC);
        }

        foreach (GameObject ennemy in ennemies)
        {
            Destroy(ennemy);
        }
        foreach (GameObject spanwn in spawns)
        {
            Destroy(spanwn);
        }
        gameEnd.GameIsEnd(true);
    }
}
