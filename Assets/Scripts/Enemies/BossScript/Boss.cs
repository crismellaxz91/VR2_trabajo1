using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    #region variables
    [SerializeField]
    Animator anim;
    public Transform target, explosionInstanceL, explosionInstanceR, stompInstance;
    NavMeshAgent agent;
    [SerializeField]
    bool enableAct;
    [SerializeField]
    int atkStep;
    public float sightRange, attackRange;
    private bool playerInSightRange, playerInAttackRange;
    public LayerMask whatIsPlayer;
    public GameObject explosion;
    #endregion
    #region BossCode
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
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (enableAct)
        {
            RotateBoss();
            ChasePlayer();
        }
    }
    void BossAttack()
    {
        if(playerInAttackRange)
        {
            switch (atkStep)
            {
                case 0:
                    atkStep += 1;
                    anim.Play("LeftAtk");
                    break;
                case 1:
                    atkStep += 1;
                    anim.Play("RightAtk");
                    break;
                case 2:
                    atkStep += 1;
                    anim.Play("Smash");
                    break;
                case 3:
                    atkStep = 0;
                    anim.Play("Stomp");
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
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    #endregion
    #region ExplosionsForTheAttack
    public void ExplosiveAttackL()
    {
        Instantiate(explosion, explosionInstanceL.position, explosion.transform.rotation);
    }
    public void ExplosiveAttackR()
    {
        Instantiate(explosion, explosionInstanceR.position, explosion.transform.rotation);
    }
    public void StompExplosiveAttack()
    {
        Instantiate(explosion, stompInstance.position, gameObject.transform.rotation);
    }
    #endregion
}
