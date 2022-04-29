using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAoE : MonoBehaviour
{
    public GameObject windAreaOfEffect;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(windAreaOfEffect, gameObject.transform.position, gameObject.transform.rotation);     
        }
    }
}
