using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    [SerializeField]
    NavMeshAgent agent;
    Vector3 destination;
    [SerializeField]
    private Animator animator;
    
    public void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        destination = agent.destination;
    }
    void Update()
    {
        var distance = Vector3.Distance(target.position, transform.position);
        if(distance <= 30)
        {
            animator.SetBool("IsWalking", true);
            agent.enabled = true;
            agent.SetDestination(target.position);
        }
        else
        {
            agent.enabled = false;
            animator.SetBool("IsWalking", false);
        }
    }
}
