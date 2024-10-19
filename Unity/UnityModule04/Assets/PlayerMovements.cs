using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private int hp = 3;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private bool isHited = false;
    [SerializeField] private bool isAlive = true;
    [SerializeField] private bool isBegin = false;
    
    private Rigidbody2D rb;
    private Animator animator;
    private float horizontalInput;
    private float timeInvinsibility = 3f;
    private TransitionLevel transition;


    //Variable for sound
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip damageSound;



    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transition = GameObject.Find("Transition").GetComponent<TransitionLevel>();

        
    }


    // Update is called once per frame
    void Update()
    {
        if (isAlive && isBegin)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            FlipPosition();
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                isGrounded = false;
                source.PlayOneShot(jumpSound);
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                animator.SetBool("isJumping", !isGrounded);
            }
        }
        else if (!isBegin)
        {
            BeginAnimation();
        }
    }

    void BeginAnimation()
    {
        //Use for the animation awake
        StartCoroutine(AnimationBegin());
    }

    IEnumerator AnimationBegin()
    {
        animator.SetBool("isBegin", isBegin);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        isBegin = true;
        animator.SetBool("isBegin", isBegin);

    }

    void AnimationDeath()
    {
        //Use when the player die
        horizontalInput = 0f;
        rb.simulated = false;
        animator.SetBool("isAlive", isAlive);
        source.PlayOneShot(deathSound);
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
        StartCoroutine(transition.GameOver());
    }

    private void FixedUpdate()
    {
        //Animation when the player move with the horizontal axe
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
    }

    void FlipPosition()
    {
        //Change the direction if the player move in oposite direction
        if (horizontalInput < 0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontalInput > 0f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemy") && !isHited)
        {
            hp--;
            Debug.Log("hp: " + hp);
            if (hp > 0)
            {
                isHited = true;
                horizontalInput = 0f;
                animator.SetBool("isHited", isHited);
                source.PlayOneShot(damageSound);
                if (collision.gameObject.transform.position.x > transform.position.x)
                {
                    transform.position = new Vector3(transform.position.x - 3f, transform.position.y, transform.position.z);
                }
                else if (collision.gameObject.transform.position.x < transform.position.x)
                {
                    transform.position = new Vector3(transform.position.x + 3f, transform.position.y, transform.position.z);
                }
                StartCoroutine(Iframes(timeInvinsibility));
            }
            else if (hp <= 0)
            {
                isAlive = false;
                AnimationDeath();
            }
        }
        
            isGrounded = true;
            animator.SetBool("isJumping", !isGrounded);
        
    }


    IEnumerator Iframes(float timeFrame)
    {
        //Frames invinsibility
        Physics2D.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(timeFrame);
        isHited = false;
        animator.SetBool("isHited", isHited);
        Physics2D.IgnoreLayerCollision(6, 7, false);

    }
}
