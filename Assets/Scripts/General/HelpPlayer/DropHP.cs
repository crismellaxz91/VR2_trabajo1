using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHP : MonoBehaviour
{
    public GameObject hpDrop;
    public float instantiateLaunchSpeed;
    public int itemsToDrop;
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("PushBullet"))
        {
            if(itemsToDrop <3)
            {
                Instantiate(hpDrop, transform.position, Quaternion.Euler(0, Random.Range(0, 4) * 90, 0));
                itemsToDrop++;
                Rigidbody rb = hpDrop.GetComponent<Rigidbody>();
                rb.velocity = Vector3.up * instantiateLaunchSpeed;
            }
        }
    }
}
