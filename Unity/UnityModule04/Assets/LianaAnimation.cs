using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LianaAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject attack;

    //Sounds Variables
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip lianaSound;

    private bool isAttack = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isTrigger", true);
            attack.SetActive(true);
            isAttack = true;
            source.clip = lianaSound;
            StartCoroutine(SoundAttack());
 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isTrigger", false);
            attack.SetActive(false);
            isAttack = false;
            source.Stop();
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
