using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntersMovement : MonoBehaviour
{

    public Vector3 pointB;
    public float HunterSpeed;


    IEnumerator Start()
    {
        HunterSpeed = 3.0f;
        var pointA = transform.position;
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, HunterSpeed));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, HunterSpeed));
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }

}
