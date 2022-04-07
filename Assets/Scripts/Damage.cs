using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;
    public string tagTarget;
    //public int hp;
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(tagTarget))
        {
            Health health = GetComponent<Health>();
            if(health != null)
            {

                health.TakeDamage(damage);
                /*if(gameObject.tag == "PushBullet")
                {
                    hp--;
                    if (hp <= 0)
                    {
                        Destroy(gameObject);
                    }
                }*/
                if(gameObject.tag == "Bullet")
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
