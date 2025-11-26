using System;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 CurrentSpawnPoint;
    public bool playerDead;
    public Rigidbody2D playerRB;

    private void Start()
    {
        
        CurrentSpawnPoint = new Vector3(-7.884f,-1.6f,0f);
    }

    void Update()
    {
        RespawnPlayer();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathBarrier"))
        {
            playerDead = true;
        }
    }

    protected void RespawnPlayer()
    {
        if (playerDead == true)
        {
            transform.position = new Vector3(playerRB.CurrentSpawnPoint.x, playerRB.CurrentSpawnPoint.y, 0);
            playerDead = false;
        }
    }
}


