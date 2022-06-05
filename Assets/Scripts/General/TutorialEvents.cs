using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialEvents : MonoBehaviour
{
    public UnityEvent otherTutorials;
    public UnityEvent endOtherTutorials;
    public GameObject textGO;
    public GameObject positionText;

    public void Start()
    {
        GameObject parent = gameObject;
        textGO = parent.transform.GetChild(0).gameObject;
        positionText = GameObject.FindGameObjectWithTag("Position").GetComponent<Transform>().gameObject;
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            otherTutorials.Invoke();
            MoveTextToPlayer();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Invoke("InvokedEvent", 2f);
        }
    }
    public void MoveTextToPlayer()
    {
        textGO.transform.position = positionText.transform.position;
    }
    public void InvokedEvent()
    {
        endOtherTutorials.Invoke();
    }
}
