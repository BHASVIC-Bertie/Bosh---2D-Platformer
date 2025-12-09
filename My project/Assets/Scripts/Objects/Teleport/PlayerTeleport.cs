using System;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private Collider2D Teleporter;
    public float finalLocationx;
    public float finalLocationy;
    public Rigidbody2D player;
    private bool teleportPlayer;
    public GameObject tutorialPlayerMessage;
    public GameObject playerMessage;
    public PlayerRespawn respawnPoint;


    
    void Start()
    {
        
        Teleporter = GetComponent<Collider2D>();
        tutorialPlayerMessage.SetActive(false);
    }

    private void Update()
    {
        //teleports the player when enter is pressed
        if (Input.GetKey("return") && teleportPlayer)
        {
            player.linearVelocity = Vector2.zero;
            player.angularVelocity = 0f;
            player.transform.position = new Vector3(finalLocationx, finalLocationy, 0f);
            respawnPoint.CurrentSpawnPoint = new Vector3(finalLocationx, finalLocationy, 0);
                
            teleportPlayer = false;
        }
    }
    //allows the player to be teleported when they are touching 
    void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                tutorialPlayerMessage.SetActive(true);
                print("player is here");
                teleportPlayer = true;
            }
        }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tutorialPlayerMessage.SetActive(false);
            
        }
    }
}