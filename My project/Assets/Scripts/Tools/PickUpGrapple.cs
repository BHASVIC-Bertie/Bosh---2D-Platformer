using UnityEngine;

public class PickUpGrapple : MonoBehaviour
{
    public GameObject grapplePickup;
    public GrapplingHook grapplingHook;
    public GameObject messageGrapple;
    
    void Start()
    {
        messageGrapple.SetActive(false);
    }
    
    //player picks up the grapple
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            grapplingHook.canUseGrapple = true;
            Destroy(grapplePickup);
            messageGrapple.SetActive(true);
        }
    }
}
