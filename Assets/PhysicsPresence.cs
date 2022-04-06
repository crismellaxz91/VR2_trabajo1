using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPresence : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //position
        rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;
        //rotation
        Quaternion rotationDiff = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDiff.ToAngleAxis(out float angleDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegree = angleDegree * rotationAxis;

        rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }
}
