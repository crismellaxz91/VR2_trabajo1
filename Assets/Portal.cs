using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform teleportPosition;
    private void OnTriggerEnter(Collider other)
    {
      if(other.CompareTag("Player"))
        {

            other.transform.position = teleportPosition.position;
        }
    }
}
