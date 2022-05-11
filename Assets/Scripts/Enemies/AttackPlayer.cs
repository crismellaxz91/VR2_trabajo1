using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public float attackRange;
    public float tiempoProximoDisparo = 0.5f;
    public float fireRate = 0.2f;
    public Rigidbody prefab;
    private Transform eye;
    private FollowPlayer follow;
    private Transform target;
    public Animator animator;
    [SerializeField]
    private Vector3 direccionAlPlayer;
    private float bulletSpeed; 
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        follow = GetComponent<FollowPlayer>();
    }
    void Update()
    {
        direccionAlPlayer = target.transform.position - transform.position;
        if (Vector3.Distance(transform.position, target.transform.position) < attackRange && Time.time >= tiempoProximoDisparo)
        {
            follow.enabled = false;
            animator.SetBool("IsAttacking", true);
            tiempoProximoDisparo = Time.time + fireRate;
        }
    }
    public void Attack() // se llama con un evento de la animacion de ataque
    {
        var projectile = Instantiate(prefab, eye.position, prefab.transform.rotation);
        projectile.AddForce(direccionAlPlayer * bulletSpeed);
        
    }
    public void EndAttakc() // se llama con un evento de la animacion de ataque
    {
        animator.SetBool("IsAttacking", false);
    }
}
