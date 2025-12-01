using UnityEngine;

public class PickUpBomb : MonoBehaviour
{
    
    public GameObject bombPickup;
    public GameObject messageBomb;

    void Start()
    {
        messageBomb.SetActive(false);
    }
    
    //player picks up the bomb
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpawnBomb spawnBomb = collision.gameObject.GetComponent<SpawnBomb>();
            spawnBomb.canUseBomb = true;
            messageBomb.SetActive(true);
            //print("bomb use now");
            Destroy(bombPickup);
        }
    }
}
