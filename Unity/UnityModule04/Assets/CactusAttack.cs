using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusAttack : MonoBehaviour
{
    [SerializeField] private Transform projectilePos;
    [SerializeField] private Animator cactusAnimation;
    [SerializeField] private GameObject projectile;

    private GameObject cactus;
    private bool playerTrigger = false;
    private Rigidbody2D rb;
    private float speed;
    private Coroutine shoot = null;
    private bool isRight = true;
    private bool isShooting = false;

    //Sounds variable

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip cactusSound;

    private void Start()
    {
        cactus = GameObject.Find("Cactus");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTrigger = true;
            cactusAnimation.SetBool("isTriger", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTrigger = false;
            cactusAnimation.SetBool("isTriger", false);
            isShooting = false;
            if (shoot != null)
            {
                StopCoroutine(shoot);
                shoot = null;

            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (cactus.transform.position.x > collision.transform.position.x)
            {
                cactus.transform.localScale = new Vector3(-1, 1, 1);
                speed = -8f;
                isRight = false;

            }  
            else if (cactus.transform.position.x < collision.transform.position.x)
            {
                cactus.transform.localScale = new Vector3(1, 1, 1);
                speed = 8f;
                isRight = true;
            }
            if (!isShooting)
            {
                isShooting = true;
                shoot = StartCoroutine(GenerateBall(speed));
            }
                
        }
    }

    IEnumerator GenerateBall(float forceX)
    {
        if (playerTrigger)
        {
            yield return new WaitForSeconds(cactusAnimation.GetCurrentAnimatorStateInfo(0).length * 2);
            GameObject copy = Instantiate(projectile, projectilePos.position, Quaternion.identity);
            source.PlayOneShot(cactusSound);
            rb = copy.GetComponent<Rigidbody2D>();
            if (rb == null)
                Debug.Log("Le rigidbody n'est pas instencié");
            DirectionProjectile(copy);
            rb.AddForce(new Vector2(forceX, 0), ForceMode2D.Impulse);
            Destroy(copy, cactusAnimation.GetCurrentAnimatorStateInfo(0).length);
            isShooting = false;
        }
        shoot = null;
    }

    void DirectionProjectile(GameObject Projectile)
    {
        if (isRight)
        {
            Projectile.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (!isRight)
        {
            Projectile.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
