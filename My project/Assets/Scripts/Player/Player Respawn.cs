using System;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 CurrentSpawnPoint;
    public bool playerDead;
    public Rigidbody2D playerRB;

    private void Start()
    {
        playerRB.position = new Vector3(-7.951138f,-1.537481f,0f);
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
        if (playerDead)
        {
            playerRB.transform.position = new Vector3(CurrentSpawnPoint.x, CurrentSpawnPoint.y, 0);
            playerDead = false;
        }
    }
}


