using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject bullet;

    [SerializeField] private GameObject turret;

    private Coroutine cor;


    public float rate;
    
    public  float dmg;


    [SerializeField] private Transform spawnPosition;

    void Start()
    {
    }

    private bool isGenerating = false;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("ennemy") && !isGenerating)
        {
            cor = StartCoroutine(Generate());
        }
    }

    IEnumerator Generate()
    {
        isGenerating = true;
        while (isGenerating)
        {
            yield return new WaitForSeconds(rate);
            GameObject copy = Instantiate(bullet, spawnPosition.position, Quaternion.identity);
            BulletScript bulletscript = copy.GetComponent<BulletScript>();
            if (bulletscript != null)
            {
                bulletscript.SetDmg(dmg);
            }
            Destroy(copy, 1.0f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ennemy"))
        {
            isGenerating = false;
            if (cor != null)
            {
                StopCoroutine(cor);
                cor = null;
            }
        }
    }

    public float GetDmg()
    {
        return dmg;
    }
}
