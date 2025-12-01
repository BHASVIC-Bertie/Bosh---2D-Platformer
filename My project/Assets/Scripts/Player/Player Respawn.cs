using System;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 CurrentSpawnPoint;
    public bool playerDead;
    public Rigidbody2D playerRB;
    
    private void Start()
    {
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        CurrentSpawnPoint = new Vector3(-7.951138f,-1.537481f,0f);
        RespawnPlayer();
    }

    void Update()
    {
        
        if (playerDead)
        {
            RespawnPlayer();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathBarrier"))
        {
            playerDead = true;
        }
    }

    public void RespawnPlayer()
    {
            print(CurrentSpawnPoint);
            playerRB.linearVelocity = Vector2.zero;
            playerRB.angularVelocity = 0f;
            playerRB.transform.position = new Vector3(CurrentSpawnPoint.x, CurrentSpawnPoint.y, 0);
            playerDead = false;
    }
}


