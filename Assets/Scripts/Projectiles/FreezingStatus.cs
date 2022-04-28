using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingStatus : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyStatus>() != null)
        {
            collision.gameObject.GetComponent<EnemyStatus>().ApplyFreezing(1);
        }
    }
}