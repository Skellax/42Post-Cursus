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

    private List <GameObject> ennemiesInRange = new List<GameObject>();


    public float rate;
    
    public  float dmg;

    public int ammo;

    public float cooldown;

    public AmmoBar ammoBar;

    


    [SerializeField] private Transform spawnPosition;

    void Start()
    {

        ammoBar.setMaxAmmo(ammo);
    }

    float GetCoolDown()
    {
        return this.cooldown;
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("ennemy") )
        {
            ennemiesInRange.Add(other.gameObject);
            if (transform.position.x < other.transform.position.x)
            {
                gameObject.transform.localScale = new Vector3(-0.75f, 0.75f, 0.75f);
            }
            else if (transform.position.x > other.transform.position.x)
            {
                gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            }
            cor = StartCoroutine(Generate());
        }
    }

    IEnumerator Generate()
    {
        while (ennemiesInRange.Count > 0)
        {
            if (ammo == 0)
            {
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(rate);
            GameObject copy = Instantiate(bullet, spawnPosition.position, Quaternion.identity);
            BulletScript bulletscript = copy.GetComponent<BulletScript>();
            ammo--;
            ammoBar.setAmmo(ammo);
            if (bulletscript != null)
            {
                bulletscript.SetDmg(dmg);
            }
            Destroy(copy, 1.5f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ennemy"))
        {
            ennemiesInRange.Remove(other.gameObject);
            if (cor != null && ennemiesInRange.Count == 0)
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
