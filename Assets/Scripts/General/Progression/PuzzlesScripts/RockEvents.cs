using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RockEvents : MonoBehaviour
{
    public UnityEvent rockEvent;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("PushBullet"))
        {
            rockEvent.Invoke();
        }
    }
    //public void OnTriggerEnter(Collider other)
    //{
    //    var earth = other.gameObject.CompareTag("PushBullet");
    //    if (earth)
    //    {
    //        rockEvent.Invoke();
    //    }
    //}
}
