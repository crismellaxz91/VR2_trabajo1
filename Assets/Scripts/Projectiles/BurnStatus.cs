using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnStatus : MonoBehaviour
{


    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<DamageOverTime>() != null)
        {
            collision.gameObject.GetComponent<DamageOverTime>().ApplyBurn(4);
        }
    }
}
