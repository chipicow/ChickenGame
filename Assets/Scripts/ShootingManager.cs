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
    }
    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        Quaternion fromAngle = transform.rotation;
        Quaternion toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (float t = 0f; t < 1f; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
            yield return null;
        }
        Shoot();
        Quaternion fromAngle2 = transform.rotation;
        Quaternion toAngle2 = Quaternion.Euler(transform.eulerAngles - byAngles);
        for (float t = 0f; t < 1f; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Lerp(fromAngle2, toAngle2, t);
            yield return null;
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > HunterFireCooldown)
        {
            StartCoroutine(RotateMe(Vector3.up * 90f , 0.5f));
            timer = 0;
        }
    }
    void Shoot()
    {
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(bulletPrefab, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
        Temporary_Bullet_Handler.name = Temporary_Bullet_Handler.name.Substring(0, Temporary_Bullet_Handler.name.Length - 7);
        Temporary_Bullet_Handler.transform.Rotate(Vector3.right * 90);
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
        Temporary_RigidBody.AddForce(transform.forward * bulletSpeed * bulletWay);
        Destroy(Temporary_Bullet_Handler, 0.8f);
    }
}
