using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionForce = 500f;
    private float explosionRadius = 2f;
    Collider2D[] playerPresent = new Collider2D[1];
    ContactFilter2D playerFilter;
    public GameObject Bomb;
    
    Rigidbody2D rb;
    ParticleSystem explosion;

    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        
        playerFilter = new  ContactFilter2D();
        playerFilter.useLayerMask = true;
        playerFilter.SetLayerMask(LayerMask.GetMask("Player"));
        playerFilter.useTriggers = true;
        playerFilter.useDepth = false;
    }   
    
    
    //executes explosion when touching the ground
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Ground")) {
            ExplodePlayer();
            Destroy(Bomb,0.5f);
        }
    }
    /*void Update()
    {
        if (Input.GetKey("e"))
        {
            
        }
    }*/

    void ExplodePlayer()
    {
        //checks for player 
        int isPlayerPresent = Physics2D.OverlapCircle(transform.position, explosionRadius, playerFilter, playerPresent);
        print(isPlayerPresent);
        if (isPlayerPresent > 0)
        {
            print("Player present");
            Vector3 forceDirection = playerPresent[0].attachedRigidbody.transform.position - transform.position;
            //use to scale force based on distance from the impulse
            float distanceModifier = 1 - (Mathf.Clamp(forceDirection.magnitude, 0, explosionRadius) / explosionRadius);
            playerPresent[0].attachedRigidbody.AddForce(forceDirection.normalized * (distanceModifier <= 0 ? 0 : explosionForce) * distanceModifier);
            
        }
    }
}
