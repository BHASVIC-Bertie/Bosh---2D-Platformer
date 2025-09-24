using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private GameObject player;
    private Collider2D playerCollider;
    public Vector3 targetPosition;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCollider = GetComponent<Collider2D>();
        playerCollider.isTrigger = false;
    }
    private void OnTriggerEnter(Collider Teleporter){
        targetPosition = new Vector3(-20.184f, 10.408f, 0f);
        player.transform.position = targetPosition;
    }
}
