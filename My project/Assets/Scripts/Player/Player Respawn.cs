using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 CurrentSpawnPoint;
    bool playerDead = false;


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
/*
    public Vector3 GetSpawnPoint { get { return CurrentSpawnPoint; } }

    public Vector3 SetSpawnPoint { set { CurrentSpawnPoint = value; } }
*/
}


