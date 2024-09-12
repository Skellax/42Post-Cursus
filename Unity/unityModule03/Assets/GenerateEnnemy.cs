using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;

public class GenerateEnnemy : MonoBehaviour
{
    [SerializeField] private GameObject ennemy;
    [SerializeField] private  string ennemyID;
    public float timeGenerate;

    public float minDelay;
    public float maxDelay;
    public Transform spawnOffset;

    public  int nbEnnemies = 0;

    private List<GameObject> ennemies = new List<GameObject>();

    public bool  canSpwan = false;

    private GameObject target;


    public float speed;

    public void ActiveSpwan(bool reponse)
    {
        canSpwan = reponse;
        if (canSpwan == true && nbEnnemies > 0)
        {
            StartCoroutine(Timer());
        }

    }

    public void SetNbEnnemies(int nb)
    {
        this.nbEnnemies = nb;
    }


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Base");
    }
 
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        while (canSpwan)
        {
            if (nbEnnemies > 0)
            {
                Debug.Log("ennemies restants: " + nbEnnemies);
                var copy = Instantiate(ennemy,  spawnOffset.position, transform.rotation);
                copy.GetComponent<LifeEnnemy>().SetSpawnManager(this);
                ennemies.Add(copy);
            }
            yield return new WaitForSeconds(timeGenerate);       
        }
    }

    void Update()
    {
        for (int i = ennemies.Count - 1; i >= 0; i--)
        {
            if (ennemies[i] != null)
            {
                Vector2 direction = target.transform.position - ennemies[i].transform.position;
                if (ennemies[i].transform.position.x < target.transform.position.x)
                {
                    ennemies[i].transform.localScale = new Vector3(-1, 1, 1);
                }
                ennemies[i].transform.Translate(direction.normalized * speed * Time.deltaTime);
                if (ennemies[i].transform == target.transform)
                {
                    DecreteEnnemies(-1);
                }
            }
            else
            {
                ennemies.RemoveAt(i);
            }

        }
    }

    public bool HasEnnemiesActive()
    {
        return ennemies.Count == 0 && nbEnnemies <= 0;
    }

    public void DecreteEnnemies(int dec)
    {
        nbEnnemies -= dec;
    }

    public string GetIdEnnemi()
    {
        return ennemyID;
    }
}
