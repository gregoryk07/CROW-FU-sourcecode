using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb2D;
    //Necesery values
    public float playerSpeed;
    public float jumpHeight;
    //for ground check
    public bool isGrounded;
    public float groundDistance = 0.1f;
    public Transform groundCheck;
    public LayerMask groundMask;

    public float movementSpurt = 5f;

    [Header("for debug")]
    public Vector2 moveVel;
    public Vector2 jumpVel;

    float InputX;
    public KeyCode jumpKey = KeyCode.Space;
    // Update is called once per frame
    void Update()
    {
        InputX = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector2 _x = new Vector2(playerSpeed, 0f);
            rb2D.AddForce(_x * -movementSpurt);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector2 _x = new Vector2(playerSpeed, 0f);
            rb2D.AddForce(_x * movementSpurt);
        }

        //moving around
        moveVel = new Vector2(InputX * playerSpeed * 2, 0f);
        rb2D.AddForce(moveVel);


        //jumping
        isGrounded = (Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundMask) && rb2D.velocity.y >= 0);

        if (isGrounded)
        {
            if (Input.GetKeyDown(jumpKey))
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        jumpVel = new Vector2(0f, jumpHeight);
        rb2D.AddForce(jumpVel);
    }
}
