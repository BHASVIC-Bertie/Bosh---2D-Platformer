using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private Collider2D Teleporter;

    void Start()
    {
        Teleporter = GetComponent<Collider2D>();
        Teleporter.isTrigger = true;
    }
    
    private void OnTriggerEnter(Collider playerCollider){
        transform.position = new Vector3(-20.184f, 10.408f, 0f);
    }
}
