using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogController : MonoBehaviour
{

    private NavMeshAgent agent;
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        if (gameObject.transform.position.x > 5f)
        {
            agent.SetDestination(new Vector3(-5.5f, 1.245f, 0));
        }
        if (gameObject.transform.position.x < -5f)
        {
            agent.SetDestination(new Vector3(5.5f, 1.245f, 0));
        }
        if (gameObject.transform.position.z > 5f)
        {
            agent.SetDestination(new Vector3(0, 1.245f, -5.5f));
        }
        if (gameObject.transform.position.z < -5f)
        {
            agent.SetDestination(new Vector3(0, 1.245f, 5.5f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
