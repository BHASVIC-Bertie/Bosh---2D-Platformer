using UnityEngine;

public class SpawnBomb : MonoBehaviour
{
    public GameObject Bomb;
    private float bombTimer; 
    
    //makes a cooldown between each bomb throw
    void Update()
    {
        bombTimer += Time.deltaTime;
        print(bombTimer);
        if (Input.GetKey("r") && bombTimer >= 2)
        {
            ThrowBomb();
            bombTimer = 0;
        }
    }
    void ThrowBomb()
    {
        GameObject newBomb = Instantiate(Bomb);
    }
    
}
