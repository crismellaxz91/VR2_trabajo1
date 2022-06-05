using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHP : MonoBehaviour
{
    public Rigidbody hpDrop;
    public float instantiateLaunchSpeed;
    public int itemsToDrop;
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("PushBullet"))
        {
            if (itemsToDrop < 3)
            {
                Instantiate(hpDrop, transform.position + new Vector3(0f, 1f, 0f), Quaternion.Euler(0, Random.Range(0, 4) * 90, 0));
                itemsToDrop++;
            }
        }
    }
}
