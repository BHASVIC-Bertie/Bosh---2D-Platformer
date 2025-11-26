using UnityEngine;

public class SpawnBomb : MonoBehaviour
{
    public GameObject Bomb;
    private float bombTimer;
    public Rigidbody2D player;
    
    //makes a cooldown between each bomb throw
    void Update()
    {
        bombTimer += Time.deltaTime;
        //print(bombTimer);
        if (Input.GetKey("r") && bombTimer >= 2)
        {
            ThrowBomb();
            bombTimer = 0;
        }
    }
    void ThrowBomb()
    {
        GameObject newBomb = Instantiate(Bomb,new Vector3(player.position.x-0.1f, player.position.y, 0), Quaternion.identity);
    }
    
}
