using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obelisk : MonoBehaviour
{
    public ProgressLVL progress;
    public GameObject obeliskHealth;
    public void Update()
    {
        Health health = obeliskHealth.GetComponent<Health>();
        if(health.health <= 0)
        {
            progress.dome1Event.Invoke();
        }
    }
}
