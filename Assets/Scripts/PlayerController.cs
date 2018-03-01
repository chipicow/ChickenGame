﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PlayerSpeed = 10f;

    void Update()
    {
        GetUserWASD();
    }

    void GetUserWASD()
    {

        Vector3 pos = transform.position;
        bool xplusz = CheckIfDiagonal();
        var speedToUse = PlayerSpeed;
        if (xplusz)
            speedToUse = DividedByHipotnouse(speedToUse);

        if (Input.GetKey("w") && pos.z < 6.5f)
        {
            pos.z += speedToUse * Time.deltaTime;
        }
        if (Input.GetKey("s") && pos.z > -6.5f)
        {
            pos.z -= speedToUse * Time.deltaTime;
        }
        if (Input.GetKey("d") && pos.x < 6.5f)
        {
            pos.x += speedToUse * Time.deltaTime;
        }
        if (Input.GetKey("a") && pos.x > -6.5f)
        {
            pos.x -= speedToUse * Time.deltaTime;
        }
        transform.position = pos;

        BlockPlayerMovingOutSideMap();

        ClickedAny();
    }

    void ClickedAny()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 moviment =  new Vector3(moveHorizontal, 0.0f, moveVertical);
        Quaternion lookRotation = Quaternion.LookRotation(moviment);
        transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, lookRotation, Time.deltaTime* PlayerSpeed*2);

        transform.Translate(moviment * PlayerSpeed * Time.deltaTime, Space.World);
    }

    bool CheckIfDiagonal()
    {
        if (Input.GetKey("w") && Input.GetKey("d") || Input.GetKey("w") && Input.GetKey("a") || Input.GetKey("s") && Input.GetKey("d") || Input.GetKey("s") && Input.GetKey("a"))
            return true;
        return false;
    }

    float DividedByHipotnouse(float catetos)
    {
        return catetos / Mathf.Sqrt(catetos * catetos * 2);
    }

    void BlockPlayerMovingOutSideMap()
    {
        if (transform.position.x > 6.5f)
        {
            Vector3 pos = transform.position;
            pos.x = 6.5f;
            transform.position = pos;
        }
        if (transform.position.x < -6.5f)
        {
            Vector3 pos = transform.position;
            pos.x = -6.5f;
            transform.position = pos;
        }
        if (transform.position.z > 6.5f)
        {
            Vector3 pos = transform.position;
            pos.z = 6.5f;
            transform.position = pos;
        }
        if (transform.position.z < -6.5f)
        {
            Vector3 pos = transform.position;
            pos.z = -6.5f;
            transform.position = pos;
        }
    }
}
