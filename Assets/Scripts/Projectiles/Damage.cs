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
    public void Start()
    {
        
    }
    public void OnCollisionEnter(Collision collision) // hacer daño en collision
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
                    Destroy(gameObject, 0.2f);
                }
            }
        }
    }
    #region eliminarProyectilesEscena
    public void OnBecameInvisible() // limpieza proyectiles en escena
    {
        if (gameObject.tag == "PushBullet")
        {
                Destroy(gameObject, 12f);
        }

        if (gameObject.tag == "Bullet")
        {
            Destroy(gameObject, 3f);
        }
    }
    public void DestroyWind() //Destruye el gameobject WindFieldPush al final de su animación
    {
        Destroy(gameObject);
    }
    public void UpdateUpdate()
    {
        OnBecameInvisible();
    }
    #endregion
}
