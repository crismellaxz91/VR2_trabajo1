using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp;
    
    public void TakeDamage(int damage)
    {
        hp -= damage;
    }    
    void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
