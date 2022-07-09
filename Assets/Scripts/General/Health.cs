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
        if (gameObject.CompareTag("Player"))
        {
            AudioSource source = gameObject.GetComponent<AudioSource>();
            source.Play();
        }
    }
    void Update()
    {
        if(health <= 0 && gameObject.tag != "Player" )
        {
            gameObject.SetActive(false);
        }
    }
}
