using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialEvents : MonoBehaviour
{
    public UnityEvent otherTutorials;
    public UnityEvent endOtherTutorials;
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            otherTutorials.Invoke();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            endOtherTutorials.Invoke();
        }
    }
}
