using System;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;
    public int moveForce = 1;

    void update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveForce * Time.deltaTime);

        Vector2 lookDir = mousePos - rb.position;
    }

}
