using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    public float ChickenSpeed = 1f;

    public float xMax = 6;
    public float zMax = 6;
    public float xMin = -6;
    public float zMin = -6;

    private float x;
    private float z;
    private float Time;
    private float angulo;

    // Use this for initialization
    void Start()
    {
        x = Random.Range(-ChickenSpeed, ChickenSpeed);
        z = Random.Range(-ChickenSpeed, ChickenSpeed);
        angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
        transform.localRotation = Quaternion.Euler(0, angulo, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Time += UnityEngine.Time.deltaTime;
        if (transform.localPosition.x > xMax)
        {
            x = Random.Range(-ChickenSpeed, 0.0f);
            angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(0, angulo, 0);
            Time = 0.0f;
        }
        if (transform.localPosition.x < xMin)
        {
            x = Random.Range(0.0f, ChickenSpeed);
            angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(0, angulo, 0);
            Time = 0.0f;
        }
        if (transform.localPosition.z > zMax)
        {
            z = Random.Range(-ChickenSpeed, 0.0f);
            angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(0, angulo, 0);
            Time = 0.0f;
        }
        if (transform.localPosition.z < zMin)
        {
            z = Random.Range(0.0f, ChickenSpeed);
            angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(0, angulo, 0);
            Time = 0.0f;
        }

        if (transform.localPosition.y < 0)
        {
            GameController.instance.KillChicken(gameObject);
        }

        if (Time > 1.0f)
        {
            x = Random.Range(-ChickenSpeed, ChickenSpeed);
            z = Random.Range(-ChickenSpeed, ChickenSpeed);
            angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(0, angulo, 0);
            Time = 0.0f;
        }

        transform.localPosition = new Vector3(transform.localPosition.x + x, transform.localPosition.y, transform.localPosition.z + z);
    }
}
