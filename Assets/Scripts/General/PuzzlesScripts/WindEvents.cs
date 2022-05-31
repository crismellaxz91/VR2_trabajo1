using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WindEvents : MonoBehaviour
{
    public UnityEvent windEvent;

    public void OnTriggerEnter(Collider other)
    {
        var wind = other.GetComponent<WindAoE>();
        if (wind != null)
        {
            windEvent.Invoke();
        }
    }
}
