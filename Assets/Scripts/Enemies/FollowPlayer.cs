using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    #region VariablesNavegacion
    public Transform target;
    [SerializeField]
    NavMeshAgent agent;
    #endregion
    #region VariablesAtaque
    public float sightRange, attackRange;
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public bool playerInSightRange, playerInAttackRange;
    public LayerMask whatIsPlayer;
    public Rigidbody prefab;
    public Transform eye;
    private Vector3 direccionAlPlayer;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    bool isAttacking;
    #endregion
    [SerializeField]
    private Animator animator;
    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }
    public void Update()
    {
        direccionAlPlayer = target.transform.position - transform.position;
        //ver si el player esta en rango de vision o de ataque
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        if (playerInAttackRange && playerInSightRange)
        {
            AttackPlayer();
        }

    }
    public void ChasePlayer()
    {
        agent.SetDestination(target.position);

    }
    public void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(target);

        if (!alreadyAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(prefab, eye.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(direccionAlPlayer * bulletSpeed);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
   private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
    #region ViejaVersion
    //void Update()
    //{
    //    distanceToShoot = target.transform.position - transform.position;
    //    var distance = Vector3.Distance(target.position, transform.position);
    //    if(distance <= 30 && distance >= attackRange)
    //    {
    //        animator.SetBool("IsWalking", true);
    //        agent.enabled = true;
    //        agent.SetDestination(target.position);
    //        FaceTarget();
    //    }
    //    else if(distance <= attackRange)
    //    {
    //        isAttacking = true;
    //    }
    //    AttackTarget();
    //}
    //void FaceTarget()
    //{
    //    var turnTowardNavSteeringTarget = agent.steeringTarget;
    //    Vector3 direction = (turnTowardNavSteeringTarget - transform.position).normalized;
    //    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0.01f, direction.z));
    //    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    //}
    //void AttackTarget()
    //{
    //    if(isAttacking)
    //    {
    //        animator.SetBool("IsWalking", false);
    //        agent.enabled = false;
    //        animator.SetBool("IsAttacking", true);
    //    }
    //}
    //public void SpawnProjectile() // se llama con un evento en la animación del enemigo
    //{
    //    var projectile = Instantiate(prefab, eye.position, prefab.transform.rotation);
    //    projectile.AddForce(distanceToShoot * bulletSpeed);
    //    isAttacking = false;
    //}
    //public void StopAttacking()
    //{
    //    if(!isAttacking)
    //    {
    //        animator.SetBool("IsAttacking", false);
    //        agent.enabled = true;
    //    }
    //}
    #endregion
}
