using UnityEngine;

public class Bullet : Turret
{
    public float speed = 10f;

    void Update()
    {
        print("moving");
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


}
