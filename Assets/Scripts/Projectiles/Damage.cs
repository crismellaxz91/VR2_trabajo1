using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    #region variables
    public int damage;
    public string tagTarget;
    private Health health;
    public int hp;
    #endregion
    public void OnCollisionEnter(Collision collision) // hacer da�o en collision
    {
        if (collision.gameObject.CompareTag(tagTarget))
        {
            health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
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
    #region eliminarProyectilesEscena
    public void OnBecameInvisible() // limpieza proyectiles en escena
    {
        if (gameObject.tag == "PushBullet")
        {
                Destroy(gameObject, 5f);
        }

        if (gameObject.tag == "Bullet")
        {
            Destroy(gameObject, 2f);
        }
    }
    public void DestroyWind() //Destruye el gameobject WindFieldPush al final de su animaci�n
    {
        Destroy(gameObject);
    }
    public void Update()
    {
        OnBecameInvisible();
    }
    #endregion
}
