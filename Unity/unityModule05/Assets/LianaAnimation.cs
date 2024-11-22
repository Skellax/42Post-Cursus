using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LianaAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D atackBox;

    //Sounds Variables
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip lianaSound;

    private bool isAttack = false;

    private float positiveX;

    private float negativeX;

    void Start()
    {
        positiveX = transform.localScale.x;
        negativeX = -transform.localScale.x;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isTrigger", true);
            isAttack = true;
            source.clip = lianaSound;
            StartCoroutine(SoundAttack());
 
        }
    }

    public void ActiveAttackBox()
    {
        atackBox.enabled = true;

    }

    public void DisactiveAtackBox()
    {
        atackBox.enabled = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isTrigger", false);
            isAttack = false;
            source.Stop();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (transform.position.x > collision.transform.position.x)
            {
                transform.localScale = new Vector3(positiveX, transform.localScale.y, transform.localScale.z);
            }
            else if (transform.position.x < collision.transform.position.x)
            {
                transform.localScale = new Vector3(negativeX, transform.localScale.y, transform.localScale.z);
            }
        }
    }

    private IEnumerator SoundAttack()
    {
        while (isAttack)
        {
            source.Play();
            yield return new WaitForSeconds(source.clip.length);
            source.Stop();
        }       
    }
}
