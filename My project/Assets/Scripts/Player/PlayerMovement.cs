using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //movement:
    public float moveForce = 6f;
    public float jumpForce = 5f;
    public Vector3 Jump;
    private float movementY;
    public float jumpAmount = 10;
    
    //player
    
    
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
        
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        PlayerJump();
        PlayerMoveKeyboard();
        PlayerTeleportButton();
    }
// Update is called once per frame
    private void FixedUpdate()
    {
    }

    void PlayerMoveKeyboard()
    {
        float movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;
        /* Use this code at some point:
        Vector3 movementX = new Vector3(Input.GetAxis("Horizontal"), 0);
        rb.MovePosition(transform.position + Time.fixedDeltaTime * moveForce * movementX);
        */   
    }
    
    void PlayerJump()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce,  ForceMode2D.Impulse);
            isGrounded = false;
            print("JUMP");
        }
    }
    
    void PlayerTeleportButton()
    {
        if (Input.GetKey("t"))
        {
            transform.position = new Vector3(-8.978f, 9.675f, 0f);
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