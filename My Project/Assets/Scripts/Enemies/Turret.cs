using UnityEngine;
using UnityEngine.Animations;

public class Turret : Enemy
{
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
    }
    

}
