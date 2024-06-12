using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public CharacterController controller;
    
    public float playerSpeed;
    public float playerJumpHeight;
    private float gravity = -4.81f;
    private Vector3 playerVelocity;

    public bool canControl = true;

    public bool Isgrounded => controller.isGrounded;

    // Update is called once per frame

    public void SetControl(bool control)
    {
        canControl = control;
    }

    void Update()
    {
        if (canControl)
        {
            Vector3 move = new Vector3(0, 0, Input.GetAxis("Horizontal"));
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move!= Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            if (!controller.isGrounded)
            {
                playerVelocity.y += gravity * Time.deltaTime;
                controller.Move(playerVelocity * Time.deltaTime);
            }
            else
            {
                playerVelocity.y = 0f;
            }

            if (controller.isGrounded && Input.GetButtonDown("Jump"))
            {
                float jumpVelocity = Mathf.Sqrt(playerJumpHeight * -2f * gravity);
                playerVelocity.y = jumpVelocity;
            }

            playerVelocity.y += gravity * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
        if (!controller.isGrounded)
        {
            playerVelocity.y += gravity * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
        else
        {
            playerVelocity.y = 0f;
        }

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }       
}

