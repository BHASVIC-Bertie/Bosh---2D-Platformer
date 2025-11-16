using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //variables
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float jumpNumber = 2;
    public float jumpsLeft;

    //player physics
    private Rigidbody2D rb;
    private bool jumpPressed;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // get movement input
        moveInput = Input.GetAxis("Horizontal");

        // get jump input
        if (Input.GetButtonDown("Jump") && jumpsLeft > 0)
        {
            jumpPressed = true;
        }

        PlayerTeleportButton();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // jump
        if (jumpPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpPressed = false;
            jumpsLeft--;
        }
    }
    void PlayerTeleportButton()
    {
        if (Input.GetKey("t"))
        {
            transform.position = new Vector3(-8.978f, 9.68706f, 0f);
        }
    }
    private bool isGrounded;
    
    //checks if player is touching the ground
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
            jumpsLeft = jumpNumber;
            //print("grounded:" + isGrounded);
        }
    } 
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            //print("grounded:" + isGrounded);
        }
    }
}