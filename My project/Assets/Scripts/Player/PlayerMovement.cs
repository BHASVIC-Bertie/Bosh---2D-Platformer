using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveForce = 10f;
    private float movementX;
    private float movementY;
void Update()
{
    PlayerMoveKeyboard();

}

void PlayerMoveKeyboard()
{
    movementX = Input.GetAxisRaw("Horizontal");
    transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;

}
}