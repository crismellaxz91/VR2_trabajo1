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
    public float speedBoss;
    public float sightRange;
    public bool playerInSightRange;
    public LayerMask whatIsPlayer;
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enableAct = true;
        agent = gameObject.GetComponent<NavMeshAgent>();
    }
    public void ChasePlayer()
    {
        agent.SetDestination(target.position);
        anim.SetBool("Walk", true);
    }
    public void RotateBoss()
    {
      Vector3 dir = target.transform.position - transform.position;
      transform.localRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 5 * Time.deltaTime);
    }
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        if (enableAct)
        {
            RotateBoss();
            ChasePlayer();
        }
    }
    void BossAttack()
    {
        if((target.position - transform.position).magnitude < 10)
        {
            switch(atkStep)
            {
                case 0:
                    atkStep += 1;
                    anim.Play("");
                    break;
                case 1:
                    atkStep += 1;
                    anim.Play("");
                    break;
                case 2:
                    atkStep = 0;
                    anim.Play("");
                    break;
            }
        }
    }
    void FreezeBoss()
    {
        enableAct = false;
    }
    void UnFreezeBoss()
    {
        enableAct = true;
    }
    private void OnDrawGizmosSelected() // visualizacion rangos de vision y ataque
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
