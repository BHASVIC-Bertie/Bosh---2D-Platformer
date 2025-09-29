using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveForce = 6f;
    public float jumpForce = 10f;
    private float movementY;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        PlayerMoveKeyboard();
        PlayerJump();
        PlayerTeleportButton();
    }
    
    void PlayerMoveKeyboard()
    {
        
        Vector3 movementX = new Vector3(Input.GetAxis("Horizontal"), 0);
        rb.MovePosition(transform.position + Time.fixedDeltaTime * moveForce * movementX);
        
    }

    void PlayerJump()
    {
        if (Input.GetKey("e"))
        {
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

}