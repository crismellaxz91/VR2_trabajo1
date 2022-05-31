using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WaterEvents : MonoBehaviour
{
    public UnityEvent waterEvent;
    public void OnTriggerEnter(Collider other)
    {
        //var fire = other.GetComponent<FreezingStatus>();
        //if (fire != null)
        //{
        //    waterEvent.Invoke();
        //}
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            waterEvent.Invoke();
        }
    }
}
