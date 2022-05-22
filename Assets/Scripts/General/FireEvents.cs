using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
public class FireEvents : MonoBehaviour
{
    public UnityEvent fireEvent;

    public void OnTriggerEnter(Collider other)
    {
        var water = other.GetComponent<FreezingStatus>();
        if (water != null)
        {
            fireEvent.Invoke();
        }
    }
}
