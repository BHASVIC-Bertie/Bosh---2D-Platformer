using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float explosionForce = 100f;
    private float explosionRadius = 1f;
    Collider2D[] playerPresent = new Collider2D[1];
    ContactFilter2D playerFilter;
    
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
    void Update()
    {
        if (Input.GetKey("e"))
        {
            ExplodePlayer();
        }
    }

    void ExplodePlayer()
    {
        //checks for player 
        int isPlayerPresent = Physics2D.OverlapCircle(transform.position, explosionRadius, playerFilter, playerPresent);
        print(isPlayerPresent);
        if (isPlayerPresent > 0)
        {
            print("Player present");
            Vector3 forceDirection = rb.transform.position - transform.position;
            //use to scale force based on distance from the impulse
            float distanceModifier = 1 - (Mathf.Clamp(forceDirection.magnitude, 0, explosionRadius) / explosionRadius);
            rb.AddForce(forceDirection.normalized * (distanceModifier <= 0 ? 0 : explosionForce) * distanceModifier);
        }
    }
}
