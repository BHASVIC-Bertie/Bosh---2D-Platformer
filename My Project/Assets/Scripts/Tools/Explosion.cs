using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float explosionForce = 10f;
    private float explosionRadius = 5f;
    Collider2D[] PlayerPresent = new Collider2D[1];
    ContactFilter2D PlayerCollider;
    
    Rigidbody2D rb;
    ParticleSystem explosion;

    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
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
        int isPlayerPresent = Physics2D.OverlapCircle(transform.position, explosionRadius, PlayerCollider, PlayerPresent);
        print(isPlayerPresent);
        if (isPlayerPresent > 0)
        {
            print("Player present");
            Vector3 forceDirection = rb.transform.position - transform.position;
            //use to scale force based on distance from the impulse
            float distanceModifier = 1 - (Mathf.Clamp(forceDirection.magnitude, 0, explosionRadius) / explosionRadius);
        }
    }
}
