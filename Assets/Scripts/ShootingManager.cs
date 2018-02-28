using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{

    // Use this for initialization

    public GameObject bulletPrefab;
    public Transform ShootingZone;
    public float HunterFireCooldown;
    private float bulletWay = 1f;
    private float bulletSpeed = 6f;

    IEnumerator Start()
    {
        if (gameObject.name == "RigthHunter")
            bulletWay = -1f;
        while (true)
        {
            yield return StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
        Rotate();
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            transform.position + transform.right * bulletWay,
            transform.rotation);
        // Add velocity to the bullettransform.forward
        bullet.GetComponent<Rigidbody>().AddForce(transform.right * 10 * bulletWay, ForceMode.Impulse);

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
        yield return new WaitForSeconds(HunterFireCooldown);
    }
    void Rotate()
    {
        float moveVertical = Input.GetAxisRaw("Vertical");
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.rotation = Quaternion.LookRotation(movement);

        transform.Translate(movement * 20.0f * Time.deltaTime, Space.World);
    }
}
