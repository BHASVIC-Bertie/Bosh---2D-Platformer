using System;
using UnityEngine;

public class Enemy : PlayerRespawn
{
    public PlayerRespawn playerRespawn;
    private Vector3 playerRespawnPoint;


    void Start()
    {
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        playerRespawn = FindObjectOfType<PlayerRespawn>();
        playerRespawnPoint = playerRespawn.CurrentSpawnPoint;
    }


    //damages the player
    void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerRespawn.playerDead = true;
                print(playerRespawn.playerDead);
                
            }
        }
        void Update()
        {
            print(playerRespawnPoint );
            if (playerRespawn.playerDead)
            {
                playerRespawn.RespawnPlayer();
                
            }
        }

}
