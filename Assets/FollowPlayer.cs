using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    Vector3 destination;

    public void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        destination = agent.destination;
    }
    void Update()
    {
        //agent.SetDestination(target.position);
        if (Vector3.Distance(destination, target.position) > 1.0f)
        {
            destination = target.position;
            agent.destination = destination;
        }
    }
}
