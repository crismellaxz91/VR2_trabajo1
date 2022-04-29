using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBack : MonoBehaviour
{
    public float force;
    public void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "AoE")
        {
            Vector3 dir = c.contacts[0].point - transform.position;
            dir = -dir.normalized;
            GetComponent<Rigidbody>().AddForce(dir * force);
        }
    }
}
