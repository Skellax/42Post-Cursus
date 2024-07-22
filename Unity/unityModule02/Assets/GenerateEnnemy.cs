using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnnemy : MonoBehaviour
{
    [SerializeField] private GameObject ennemy;
    public float generate;

    public Vector2 spawnOffset;

    private List<GameObject> ennemies = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(generate);
            var copy = Instantiate(ennemy, spawnOffset, transform.rotation);
            ennemies.Add(copy);
            Debug.Log("ennemy poped !");
        }
    }

    void Update()
    {
        foreach(var ennemy in ennemies)
        {
            if (ennemy != null)
            {
                ennemy.transform.Translate(Vector2.down * 1 * Time.deltaTime);
            }
        }
    }
}
