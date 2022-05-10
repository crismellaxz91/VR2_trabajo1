using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public float attackRange;
    public float tiempoProximoDisparo = 0.5f;
    public float fireRate = 0.2f;
    public Rigidbody prefab;
    public Transform eye;
    public FollowPlayer follow;
    public Transform target;
    public Animator animator;
    [SerializeField]
    private Vector3 direccionAlPlayer;
    private float bulletSpeed; 
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        Vector3 direccionAlPlayer = target.transform.position - transform.position;

        if (Vector3.Distance(transform.position, target.transform.position) < attackRange && Time.time >= tiempoProximoDisparo)
        {
            tiempoProximoDisparo = Time.time + fireRate;
            var projectile = Instantiate(prefab, eye.position, prefab.transform.rotation);
            projectile.AddForce(direccionAlPlayer * bulletSpeed);
        }
    }
    public void Attack()
    {

    }
}
