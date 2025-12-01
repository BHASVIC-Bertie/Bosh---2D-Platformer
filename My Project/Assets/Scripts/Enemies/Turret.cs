using UnityEngine;
using UnityEngine.Animations;

public class Turret : Enemy
{
    public Transform shooter;
    public GameObject bullet;
    public Transform turret;
    private float shootTimer;
    float distanceToPlayer;
    private float shootRadius = 10f;
    
    //rotates towards player
    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(
            playerRespawn.playerRB.transform.position - transform.position ,
            transform.TransformDirection(Vector3.up)
        );
        transform.rotation = new Quaternion( 0 , 0 , rotation.z , rotation.w );
        
    }

    void Update()
    {
        lookAtPlayer();

        distanceToPlayer = Vector3.Distance(transform.position, playerRespawn.playerRB.transform.position);

        if (distanceToPlayer < shootRadius)
        {
            //fires the bullet
            shootTimer += Time.deltaTime;
            //print(bombTimer);
            if (shootTimer >= 1)
            {
                Shoot();
                shootTimer = 0;
            }
        }

    }

    void Shoot()
    {
        GameObject b = Instantiate(bullet, shooter.position, shooter.rotation);

        Bullet bulletScript = b.GetComponent<Bullet>();
        Vector3 dir = playerRespawn.playerRB.transform.position - shooter.position;
        bulletScript.SetDirection(dir);

    }

}
