using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreHP : MonoBehaviour
{
    [SerializeField]
    private int hpToRestore;
    [SerializeField]
    private int hpMax;
    [SerializeField]
    private Health playerHealth;

    public void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(playerHealth.health < 20 && playerHealth.health > 0)
            {
                playerHealth.health += hpToRestore;
            }
        }
    }
}
