using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private Collider2D Teleporter;
    public float finalLocationx;
    public float finalLocationy;
    public Rigidbody2D player;
    void Start()
    {
        Teleporter = GetComponent<Collider2D>();
    }
//teleports the player on collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("player is here");
            player.linearVelocity = Vector2.zero;
            player.angularVelocity = 0f;
            player.transform.position = new Vector3(finalLocationx, finalLocationy, 0f);
           
        }
    }
}
