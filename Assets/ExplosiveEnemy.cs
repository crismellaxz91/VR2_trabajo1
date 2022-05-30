using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveEnemy : MonoBehaviour
{
    public float agroRange;
    public float attackRange;
    public float speed;
    public bool playerInAgroRange, playerInAttackRange;
    public bool isOnSight;
    public LayerMask whatIsPlayer;
    public Animator animator;
    public GameObject explosion;
    public Transform player;
    public float minDistance;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;   
    }
    void Update()
    {
        playerInAgroRange = Physics.CheckSphere(transform.position, agroRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position /*+ new Vector3(0, 1, 0)*/, attackRange, whatIsPlayer);
        if (playerInAgroRange)
        {
            animator.SetTrigger("OnSight");
        }
        if(isOnSight)
        {
            Movement();
        }
        if(playerInAttackRange)
        {
            Attack();
        }
    }
    public void Movement()
    {
        transform.LookAt(player);
        if(Vector3.Distance(transform.position, player.position) >= minDistance)
        {
            animator.SetBool("Moving", true);
            Vector3 follow = player.position;
            this.transform.position = Vector3.MoveTowards(this.transform.position, follow, speed * Time.deltaTime);  
        }
        else
        {
            isOnSight = false;
            animator.SetBool("Moving", false);
        }
    }
    public void Attack()
    {
        animator.SetBool("Moving", false);
        animator.SetBool("OnRange", true);
    }
    private void OnDrawGizmosSelected() // visualizacion rangos de vision y ataque
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position /*+ new Vector3(0, 1, 0)*/, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, agroRange);
    }
    public void OnSight()
    {
        isOnSight = true;
    }
    public void Explode()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
