using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CasstleLive : MonoBehaviour
{
    [SerializeField] private int hp = 5;
    [SerializeField] private GameObject hpText;
    // Start is called before the first frame update


     

    // Update is called once per frame

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ennemy"))
        {
            Debug.Log("HP: " + hp);
            hp--;
            ShowDamage("HP: " + hp.ToString());
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
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("turret");
        GameObject spawn = GameObject.FindWithTag("Spawn");

        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }

        foreach (GameObject turret in turrets)
        {
            Destroy(turret);
        }

        foreach (GameObject ennemy in ennemies)
        {
            Destroy(ennemy);
        }
        Destroy(spawn);
        Debug.Log("Game Over");
    }

    void ShowDamage(string text)
    {
        if (hpText)
        {
            GameObject Hptext = Instantiate(hpText, new Vector3(-0.67f, -8.0f, -0.11f), Quaternion.identity);
            Hptext.GetComponentInChildren<TextMesh>().text = text;
            Destroy(Hptext, 1.0f);

        }
    }
}
