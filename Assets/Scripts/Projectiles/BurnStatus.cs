using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnStatus : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<EnemyStatus>() != null)
        {
            collision.gameObject.GetComponent<EnemyStatus>().ApplyBurn(4);
        }
    }
}
