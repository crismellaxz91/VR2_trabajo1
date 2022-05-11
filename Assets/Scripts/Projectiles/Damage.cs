using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;
    public string tagTarget;
    private Health health;
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
    public void OnBecameInvisible()
    {
        if (gameObject.tag == "PushBullet")
        {
                Destroy(gameObject, 0.5f);
        }

        if (gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
    public void DestroyWind() //Destruye el gameobject WindFieldPush al final de su animación
    {
        Destroy(gameObject);
    }
}
