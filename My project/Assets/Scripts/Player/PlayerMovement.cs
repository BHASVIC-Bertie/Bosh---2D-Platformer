using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //movement:
    public float moveForce = 6f;
    public float jumpForce = 50f;
    public Vector3 Jump;
    private float movementY;
    
    //player
    
    
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 CurrentSpawnPoint;
        CurrentSpawnPoint = new Vector3(-7.884f,-1.6f,0f);
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
        Vector3 movementX = new Vector3(Input.GetAxis("Horizontal"), 0);
        rb.MovePosition(transform.position + Time.fixedDeltaTime * moveForce * movementX);
    }
    
    void PlayerJump()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            
            rb.AddForce(new Vector2(0f, jumpForce),  ForceMode2D.Impulse);
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
            print("grounded");
        }
    } 
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            print("not grounded");
        }
    }


}