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
    Vector3 destination;
    [SerializeField]
    private Animator animator;
    #endregion
    #region VariablesAtaque
    public float attackRange;
    public float tiempoProximoDisparo = 0.5f;
    public float fireRate = 0.2f;
    public Rigidbody prefab;
    public Transform eye;
    private Vector3 distanceToShoot;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    bool isAttacking;
    #endregion
    public void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        destination = agent.destination;
    }
    void Update()
    {
        distanceToShoot = target.transform.position - transform.position;
        var distance = Vector3.Distance(target.position, transform.position);
        if(distance <= 30 && distance >= attackRange)
        {
            animator.SetBool("IsWalking", true);
            agent.enabled = true;
            agent.SetDestination(target.position);
            FaceTarget();
        }
        else if(distance <= attackRange)
        {
            isAttacking = true;
        }
        AttackTarget();
    }
    void FaceTarget()
    {
        var turnTowardNavSteeringTarget = agent.steeringTarget;
        Vector3 direction = (turnTowardNavSteeringTarget - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0.01f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }
    void AttackTarget()
    {
        if(isAttacking)
        {
            animator.SetBool("IsWalking", false);
            agent.enabled = false;
            animator.SetBool("IsAttacking", true);
        }
    }
    public void SpawnProjectile() // se llama con un evento en la animación del enemigo
    {
        var projectile = Instantiate(prefab, eye.position, prefab.transform.rotation);
        projectile.AddForce(distanceToShoot * bulletSpeed);
        isAttacking = false;
    }
    public void StopAttacking()
    {
        if(!isAttacking)
        {
            animator.SetBool("IsAttacking", false);
            agent.enabled = true;
        }
    }
}
