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
        animator = GetComponent<Animator>();
    }
    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void Update()
    {
        Health health = target.gameObject.GetComponent<Health>();
        direccionAlPlayer = target.transform.position - transform.position; //dirección proyectil
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
        if(health.health <= 0)
        {
            this.enabled = false;
        }
    }
    public void ChasePlayer()
    {
        agent.SetDestination(target.position);
        animator.SetBool("IsWalking", true);
    }
    public void AttackPlayer()
    {
        animator.SetBool("IsWalking", false);
        //agent.SetDestination(transform.position);
        transform.LookAt(target);

        if (!alreadyAttacked)
        {
            ///Attack code here
            animator.SetBool("IsAttacking", true);
            Rigidbody rb = Instantiate(prefab, eye.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(direccionAlPlayer * bulletSpeed);
            ///End of attack code
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
   private void ResetAttack() 
    {
        animator.SetBool("IsAttacking", false);
        alreadyAttacked = false;
    }
    private void OnDrawGizmosSelected() // visualizacion rangos de vision y ataque
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
