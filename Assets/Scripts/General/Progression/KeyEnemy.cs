using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyEnemy : MonoBehaviour
{
    public Health hpKeyEnemy;
    public ProgressLVL progress;
    public void Update()
    {
       hpKeyEnemy = gameObject.GetComponent<Health>();
        if (hpKeyEnemy.health <= 0)
        {
            OnDeath();
        }
    }
    public void OnDeath()
    {
        
    }
}
