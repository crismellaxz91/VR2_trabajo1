using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    public Transform target;
    NavMeshAgent agent;
    [SerializeField]
    bool enableAct;
    int atkStep;
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enableAct = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChasePlayer()
    {
        if((target.position - transform.position).magnitude >= 10)
        {
            agent.SetDestination(target.position);
            anim.SetBool("Walk", true);
        }
        if((target.position - transform.position).magnitude < 10)
        {
            anim.SetBool("Walk", false);
        }
    }
    public void RotateBoss()
    {
      Vector3 dir = target.transform.position - transform.position;
      transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(dir), 5 * Time.deltaTime);
    }
}
