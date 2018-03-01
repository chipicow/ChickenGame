using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float HunterFireCooldown;
    public GameObject Bullet_Emitter;
    private float bulletWay = 1f;
    private float bulletSpeed = 1000f;
    private float timer;
    void Start()
    {
        if (gameObject.name == "RigthHunter")
            bulletWay = -1f;
        //InvokeRepeating("Shoot", 3f, HunterFireCooldown);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= HunterFireCooldown - 0.5f)
        {
            //turn the player red , animation or rotation
        }
        if (timer > HunterFireCooldown)
        {
            Shoot();
            timer = 0;
        }
    }
    void Shoot()
    {
        //The Bullet instantiation happens here.
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(bulletPrefab, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
        //removing (clone) in bullet object
        Temporary_Bullet_Handler.name = Temporary_Bullet_Handler.name.Substring(0, Temporary_Bullet_Handler.name.Length - 7);

        Temporary_Bullet_Handler.transform.Rotate(Vector3.forward * 90);

        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

        Temporary_RigidBody.AddForce(transform.right * bulletSpeed * bulletWay);

        Destroy(Temporary_Bullet_Handler, 0.8f);
    }
}
