using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{

    public float ChickenSpeed = 2f;
    public GameObject player;
    float radius = 6.5f; //radius of map
    Vector3 centerPosition = new Vector3(0, 0, 3.12f); //center of map
    private Vector3 initialPosition;

    //void Update()
    //{
    //    float distance = Vector3.Distance(gameObject.transform.position, centerPosition);
    //    if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 5f && distance < radius)
    //    {
    //        Vector3 moveDir = gameObject.transform.position - player.transform.position;
    //        transform.Translate(moveDir.normalized * ChickenSpeed * Time.deltaTime);
    //    }
    //}
    void Start()
    {
        initialPosition = gameObject.transform.position;
        InvokeRepeating("SetRandomPos", 0, 1);
    }

    void SetRandomPos()
    {
        Vector3 temp = new Vector3(Random.Range(centerPosition.x - radius, centerPosition.x + radius) * Time.deltaTime,
            initialPosition.y,
            Random.Range(centerPosition.z - radius, centerPosition.z + radius) * Time.deltaTime);
        transform.position = temp;
    }
}
