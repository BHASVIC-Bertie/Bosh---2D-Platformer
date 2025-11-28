using UnityEngine;
using UnityEngine.Animations;

public class Turret : Enemy
{
    public Transform shooter;
    public Transform turret;
    public GameObject bullet;
    
    
    
    //rotates towards player
    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(
            playerRB.transform.position - transform.position ,
            transform.TransformDirection(Vector3.up)
        );
        transform.rotation = new Quaternion( 0 , 0 , rotation.z , rotation.w );
        
    }

    void Update()
    {
        lookAtPlayer();
        Shoot();
    }

    void Shoot()
    {
        Quaternion rotated = Quaternion.Euler(0f,0f, shooter.rotation.z + 90);
        Instantiate(bullet, shooter.position, rotated);
    }

}
