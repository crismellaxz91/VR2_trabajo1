using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;
    public string tagTarget;
    public Health health;
    public int hp;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagTarget))
        {
            health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {

                health.TakeDamage(damage);
                Debug.Log("hit");
                if(gameObject.tag == "PushBullet")
                {
                    hp--;
                    if (hp <= 0)
                    {
                        Destroy(gameObject);
                    }
                }
                if (gameObject.tag == "Bullet")
                {
                    Destroy(gameObject);
                }
            }
        }
    }
   /* public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(tagTarget))
       {
            health = other.GetComponent<Health>();
            if(health != null)
            {

                health.TakeDamage(damage);
                Debug.Log("hit");
                /*if(gameObject.tag == "PushBullet")
                {
                    hp--;
                    if (hp <= 0)
                    {
                        Destroy(gameObject);
                    }
                }
                if(gameObject.tag == "Bullet")
                {
                    Destroy(gameObject);
                }
            }
        }
    }*/
}
