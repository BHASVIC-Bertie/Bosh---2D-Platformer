using UnityEditor.U2D.Sprites;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{
    public GameObject Bomb;
    private float bombTimer;
    public Rigidbody2D player;
    public bool canUseBomb;
    
    //makes a cooldown between each bomb throw
    void Update()
    {
        bombTimer += Time.deltaTime;
        if (Input.GetKey("r") && bombTimer >= 2)
        {
            //print("bomb tried" + canUseBomb);
            if (canUseBomb)
            {
                //print("bombing");
                ThrowBomb();
                bombTimer = 0;
            }
        }
    }
    void ThrowBomb()
    {
        
            GameObject newBomb = Instantiate(Bomb, new Vector3(player.position.x + 0.025f, player.position.y, 0), Quaternion.identity);
    }
    
}
