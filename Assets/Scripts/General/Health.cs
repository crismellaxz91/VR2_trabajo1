using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public void TakeDamage(int damage)
    {
        health -= damage;
    }    
    void Update()
    {
        
        if(health <= 0 && gameObject.tag != "Player" )
        {
            Destroy(gameObject);
        }
        if(health <= 0 && gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
