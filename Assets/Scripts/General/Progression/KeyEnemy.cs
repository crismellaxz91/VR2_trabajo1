using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyEnemy : MonoBehaviour
{
    public Health hpKeyEnemy;
    public ProgressLVL progress;
    public void Update()
    {
       //progress = FindObjectOfType<ProgressLVL>();
       hpKeyEnemy = gameObject.GetComponent<Health>();
        if (hpKeyEnemy.health <= 0)
        {
            OnDeath();
        }
    }
    public void OnDeath()
    {
        progress.specialEnemies.Remove(gameObject);
    }
}
