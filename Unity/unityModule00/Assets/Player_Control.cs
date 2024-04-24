using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Control : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public Transform groundCheck;

    public LayerMask groundMask;
    public float gravity = -9.81f;
    public float groundDistance = 0.2f;

    public float jump = 1f;

    private Vector3 velocity;
    private bool isGrounded;


    // Start is called before the first frame update
  
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       if (controller == null)
       {
            return;
       }

     
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float moveLR = Input.GetAxisRaw("Horizontal");
        float moveFB = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(moveLR, 0f, moveFB).normalized;

        if (direction.magnitude > 0.1f)
        {
            controller.Move(direction *  speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2.0f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (controller.transform.position.y < 1.36f)
        {
            Debug.Log("Game Over");
            Destroy(controller.gameObject);
        }

        if (controller.transform.position.x < -7.9f &&  controller.transform.position.z > 4.7f && controller.transform.position.z < 5.2f)
        {
            Debug.Log("You win !");
            Destroy(controller.gameObject);
        }
    }

}
