using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogController : MonoBehaviour
{
    void Start()
    {
        if (gameObject.transform.position.x > 5f)
        {
            gameObject.GetComponent<NavMeshAgent>().SetDestination(new Vector3(-5.5f, 1.245f, 0));
        }
        if (gameObject.transform.position.x < -5f)
        {
            gameObject.GetComponent<NavMeshAgent>().SetDestination(new Vector3(5.5f, 1.245f, 0));
        }
        if (gameObject.transform.position.z > 5f)
        {
            gameObject.GetComponent<NavMeshAgent>().SetDestination(new Vector3(0, 1.245f, -5.5f));
        }
        if (gameObject.transform.position.z < -5f)
        {
            gameObject.GetComponent<NavMeshAgent>().SetDestination(new Vector3(0, 1.245f, 5.5f));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
