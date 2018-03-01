using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntersMovement : MonoBehaviour
{
    public Vector3 pointB;
    public float HunterSpeed;
    private Vector3 pointA;

    private float timer;
    void Awake()
    {
        HunterSpeed = 3.0f;
        pointA = transform.position;
        StartCoroutine(MoveObject(transform, pointA, pointB, HunterSpeed));
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > HunterSpeed*2)
        {
            StartCoroutine(MoveObject(transform, pointA, pointB, HunterSpeed));
            timer = 0;
        }

    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        Debug.Log("moving to point B");
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
        i = 0;
        Debug.Log("moving to point a");
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(endPos, startPos, i);
            yield return null;
        }

    }
}
