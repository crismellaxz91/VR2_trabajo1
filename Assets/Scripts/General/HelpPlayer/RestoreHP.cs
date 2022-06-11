using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreHP : MonoBehaviour
{
    [SerializeField]
    private int hpToRestore;
    [SerializeField]
    private Health playerHealth;
    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (playerHealth.health < 20 && playerHealth.health > 0)
            {
                playerHealth.health += hpToRestore;
                if (playerHealth.health > 20)
                {
                    playerHealth.health = 20;
                }
            }
            Destroy(gameObject);
        }
    }
}
