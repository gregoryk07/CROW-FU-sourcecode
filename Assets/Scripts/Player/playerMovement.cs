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
    public bool canDoubleJump;
    public float groundDistance = 0.1f;
    public Transform groundCheck;
    public LayerMask groundMask;

    public float movementSpurt = 5f;

    [Header("for debug")]
    public Vector2 moveVel;
    public Vector2 jumpVel;
    bool x = false;
    float InputX;
    public KeyCode jumpKey = KeyCode.Space;
    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            

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
        }
        InputX = Input.GetAxis("Horizontal");

        //moving around
        moveVel = new Vector2(InputX * playerSpeed * 2, 0f);
        rb2D.AddForce(moveVel);


        //jumping
        isGrounded = (Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundMask) && rb2D.velocity.y >= 0);


        if (isGrounded)
        {
            canDoubleJump = true;
            if (Input.GetKeyDown(jumpKey))
            {
                Jump();
            }
        }
        if (canDoubleJump && !isGrounded)
        {
            if (Input.GetKeyDown(jumpKey))
            {
                canDoubleJump = false;
                Jump();
            }
        }
        if (isGrounded)
        {
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
            /*if(Input.GetKeyUp(KeyCode.A))
            {
                Vector2 _x = new Vector2(-playerSpeed, 0f);
                rb2D.AddForce(_x * -movementSpurt);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                Vector2 _x = new Vector2(-playerSpeed, 0f);
                rb2D.AddForce(_x * movementSpurt);
            }*/
        }
    }

    void Jump()
    {
        jumpVel = new Vector2(0f, jumpHeight);
        rb2D.AddForce(jumpVel);
        if (!x)
        {
            AdvancementManager.instance.TriggerAdvancement(0);
            x = true;
        }
    }
}
