using UnityEngine;

public class Bullet : Enemy
{
    public float speed = 6;
    private Vector3 moveDirection;

    // Call this immediately after instantiating the bullet
    
    public void SetDirection(Vector3 dir)
    {
        moveDirection = dir.normalized;
        transform.rotation = Quaternion.LookRotation(moveDirection);
    }

    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
        
        if (playerDead)
        {
            RespawnPlayer();
            playerRB.transform.position = new Vector3(CurrentSpawnPoint.x, CurrentSpawnPoint.y, 0);
        }
    }

    void Start()
    {
       playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

        CurrentSpawnPoint = new Vector3(-7.951138f, -1.537481f, 0f);
        Destroy(gameObject, 5f); // destroy after 5 seconds
        transform.rotation = Quaternion.Euler(0, -180, playerRB.position.y);

    }
}
