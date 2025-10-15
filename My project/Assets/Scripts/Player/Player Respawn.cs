using System;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 CurrentSpawnPoint;
    public bool playerDead = false;

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

    void RespawnPlayer()
    {
        if (playerDead == true)
        {
            transform.position = new Vector3(CurrentSpawnPoint.x, CurrentSpawnPoint.y, CurrentSpawnPoint.z);
            playerDead = false;
        }
    }
}


