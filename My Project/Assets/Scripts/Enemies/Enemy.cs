using System;
using UnityEngine;

public class Enemy : PlayerRespawn
{
    void Update()
    {
       RespawnPlayer();
    }
    
    //damages the player
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player")) {
            playerDead =  true;
        }
    } 
    
}
