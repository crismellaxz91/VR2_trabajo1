using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
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
    private Vector3 direccionAlPlayer;
    [SerializeField]
    bool isAttacking;
    #endregion
    [SerializeField]
    private Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
