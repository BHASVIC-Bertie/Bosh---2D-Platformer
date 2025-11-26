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
    private GrapplingHook grapplingHook;
    public bool isGrappling;

    void Start()
    {
        grapplingHook = GetComponent<GrapplingHook>();
        isGrappling = false;
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
    }

    void FixedUpdate()
    {
        //if (!grapplingHook.isGrappling)
        {
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        }
       // else
        {
            rb.AddForce(new Vector2(moveInput * moveSpeed * 10f, 0));
        }

        // jump
        if (jumpPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpPressed = false;
            jumpsLeft--;
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