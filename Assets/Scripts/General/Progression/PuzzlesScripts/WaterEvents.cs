using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
public class WaterEvents : MonoBehaviour
{
    public UnityEvent waterEvent;

    public void OnTriggerEnter(Collider other)
    {
        var water = other.GetComponent<FreezingStatus>();
        if (water != null)
        {
            waterEvent.Invoke();
        }
    }
}
