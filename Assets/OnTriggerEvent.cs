using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEvent : MonoBehaviour
{
    public ProgressLVL progressLVL;
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            progressLVL.endingEvent.Invoke();
        }
    }
}
