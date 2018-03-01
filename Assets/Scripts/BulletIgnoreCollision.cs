﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletIgnoreCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Chicken")
        {

            Debug.Log("Collision");
            Physics.IgnoreCollision(col.collider, gameObject.GetComponent<CapsuleCollider>() );
        }
    }
}
