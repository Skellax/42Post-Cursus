using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovements : MonoBehaviour
{
    //Rigidbody Jump and another Physics
    
    [SerializeField] private bool isHited = false;
    [SerializeField] private bool isAlive = true;
    [SerializeField] private bool isBegin = false;
    
    private Rigidbody2D rb;
    private Animator animator;
    private float horizontalInput;
    private float timeInvinsibility = 3f;
    private TransitionLevel transition;
    [SerializeField] private float speed;


    //Variables jump

    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private float jumpStartTime;
    private float jumpTime;
    private bool isJumping;

    //Variable Safeposition

    private GameObject currentSafeSpawn;

    //Variable for sound
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip damageSound;


    //Variables one way platform
    private GameObject currentOneWayPlatform;
    [SerializeField] private CapsuleCollider2D playerCollider;
    [SerializeField] private BoxCollider2D playerCollider2;

    //Variable for checking isGrounded

    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float castDistance;
    [SerializeField] private LayerMask groundLayer;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transition = GameObject.Find("Transition").GetComponent<TransitionLevel>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance == null)
        {
            Debug.Log("GameManager not instance !");
            return;
        }
        if (playerCollider == null || playerCollider2 == null)
        {
            Debug.Log("playerCollider is not instanciate !");
        }       
    }


    // Update is called once per frame
    void Update()
    {
        isGrounded = CheckGrounded();

        if (isAlive && isBegin)
        {
            //Restart  the game
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                StartCoroutine(transition.GameOver());
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (currentOneWayPlatform != null)
                {
                    StartCoroutine(DisableCollision());
                }


            }
            horizontalInput = Input.GetAxis("Horizontal");
            FlipPosition();
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                isGrounded = false;
                isJumping = true;
                jumpTime = jumpStartTime;
                source.PlayOneShot(jumpSound);
                rb.velocity = Vector2.up * jumpHeight;
                animator.SetBool("isJumping", !isGrounded);
            }
            if (Input.GetButton("Jump") && isJumping)
            {
                if (jumpTime > 0)
                {
                    rb.velocity = Vector2.up * jumpHeight;
                    jumpTime -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }
            if (Input.GetButtonUp("Jump"))
            {
                isJumping = false;
            }
        }
        else if (!isBegin)
        {
            BeginAnimation();
        }
    }

    public bool CheckGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Draw a square for checked isGrounded
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
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

    

    private void Respawn()
    {
        if (currentSafeSpawn != null)
        {
            transform.position = currentSafeSpawn.transform.position;
        }
        else
        {
            Debug.LogWarning("newPosition is not defined !");
        }
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
        //Hitted by a ennemy
        if (collision.gameObject.CompareTag("Ennemy") && !isHited)
        {
            GameManager.Instance.TakeDamage();
            if (GameManager.Instance.GetHp() > 0)
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
            else if (GameManager.Instance.GetHp() <= 0)
            {
                isAlive = false;
                GameManager.Instance.HitedRecoverer();
                GameManager.Instance.IncreaseDeath();
                AnimationDeath();
            }
        }

        //Hitted by spikes

        if (collision.gameObject.CompareTag("Spikes") && !isHited)
        {
            GameManager.Instance.TakeDamage();
            if (GameManager.Instance.GetHp() > 0)
            {        
                isHited = true;      
                horizontalInput = 0f;
                animator.SetBool("isHited", isHited);
                source.PlayOneShot(damageSound);
                Respawn();
                StartCoroutine(Iframes(timeInvinsibility));
            }
            else if (GameManager.Instance.GetHp() <= 0)
            {
                isAlive = false;
                GameManager.Instance.HitedRecoverer();
                GameManager.Instance.IncreaseDeath();
                AnimationDeath();
            }
        }

        //Interactive SafeSpawn

        if (collision.gameObject.CompareTag("SafeSpawn"))
        {
            currentSafeSpawn = collision.gameObject;
            if (currentSafeSpawn == null)
            {
                Debug.Log("currentSafeSpawn dont instance !");
            }
        }
        //Interactive Platforms
        if (collision.gameObject.CompareTag("Platform"))
        {
            currentOneWayPlatform = collision.gameObject;
            if (currentOneWayPlatform == null)
            {
                Debug.Log("Currentplatform dont instance !");
            }
            

        }

        //Interactive Bumper
        if (collision.gameObject.CompareTag("Bumper"))
        {
            rb.velocity = Vector2.up * jumpHeight * 2f;
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
            source.PlayOneShot(jumpSound);

        }
          animator.SetBool("isJumping", !isGrounded);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            currentOneWayPlatform = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();
        if (platformCollider == null)
        {
            Debug.Log("platformCollider is not instanciate");
        }
        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        Physics2D.IgnoreCollision(playerCollider2, platformCollider);
        isGrounded = false;
        animator.SetBool("isJumping", !isGrounded);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
        Physics2D.IgnoreCollision(playerCollider2, platformCollider, false);
    }


    private IEnumerator Iframes(float timeFrame)
    {
        //Frames invinsibility
        Physics2D.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(timeFrame);
        isHited = false;
        GameManager.Instance.HitedRecoverer();
        animator.SetBool("isHited", isHited);
        Physics2D.IgnoreLayerCollision(6, 7, false);

    }
}
