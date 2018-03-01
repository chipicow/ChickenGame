using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("player collision");
        if (col.gameObject.name == "Chicken")
        {
            GameController.instance.KillChicken(col.gameObject);
        }

        if (col.gameObject.name == "Bullet")
        {
            GameController.instance.PlayerDied();
        }
    }
}
