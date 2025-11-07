using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //movement:
    public float moveForce = 6f;
    private float jumpHeight = 10f;
    private float movementY;
    
    //player
    
    
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        PlayerTeleportButton();
        
    }
// Update is called once per frame
    private void FixedUpdate()
    {
        PlayerMoveKeyboard();
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        Vector3 movementX = new Vector3(Input.GetAxis("Horizontal"), 0);
        rb.MovePosition(transform.position + Time.fixedDeltaTime * moveForce * movementX);
    }
    
    void PlayerJump()
    {
        float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
        if (Input.GetButton("Jump"))//&& isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce,  ForceMode2D.Impulse);
            isGrounded = false;
            print("JUMP");
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
            print(isGrounded);
        }
    } 
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            print(isGrounded);
        }
    }


}