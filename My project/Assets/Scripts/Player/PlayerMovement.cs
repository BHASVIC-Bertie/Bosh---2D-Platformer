using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveForce = 6f;
    public float jumpForce = 5f;
    public Vector3 Jump;
    
    private float movementY;
    private Rigidbody2D rb;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        PlayerMoveKeyboard();
        PlayerTeleportButton();
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        
        Vector3 movementX = new Vector3(Input.GetAxis("Horizontal"), 0);
        rb.MovePosition(transform.position + Time.fixedDeltaTime * moveForce * movementX);
        
    }

    
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void PlayerTeleportButton()
    {
        if (Input.GetKey("f"))
        {
            transform.position = new Vector3(-8.978f, 9.675f, 0f);
        }
    }
    private bool isGrounded;
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}