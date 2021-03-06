using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class modularRayRight : MonoBehaviour
{
    public Vector3 hitPoint;

    public bool triggerBool;

    public bool dragging;

    private Ray ray;
    private RaycastHit hit;
    public LayerMask dragMask, ignoreMask;
    public float distance;

    public GameObject roca;
    public GameObject agua;
    public GameObject fuego;
    public GameObject aire;
    public GameObject objectInstance;
    public float launchVelocity;

    [Header("Transforms")]
    public Transform pivotOrigin;

    public bool rightHandDebugPC; 

    #region nodesAndInput
    [SerializeField]
    private XRNode xrNode_R = XRNode.RightHand;
    private InputDevice device_R;


    void GetDevice()
    {
        device_R = InputDevices.GetDeviceAtXRNode(xrNode_R);
    }
    private void OnEnable()
    {
        if (!device_R.isValid)
        {
            GetDevice();
        }
        else if (rightHandDebugPC)
        {
            GetDevice();
        }
    }
    #endregion

    private void Update()
    {
        OnEnable();

        if (objectInstance != null)
        {
            RaycastDrag();
        }

        if (!dragging)
        {
            objectInstance = null;
        }

        Launching();

        if (device_R.TryGetFeatureValue(CommonUsages.triggerButton, out triggerBool) && triggerBool)
        {
            Debug.Log("Triggering");
        }

        #region Ray Start  and Interactions

        ray = new Ray(pivotOrigin.transform.position, pivotOrigin.forward);

        if (Physics.Raycast(ray, out hit, distance, ignoreMask))
        {
            if (hit.collider.CompareTag("Tierra") && triggerBool && !objectInstance || hit.collider.CompareTag("Tierra") && rightHandDebugPC && !objectInstance)
            {
                InstanceRock();

            }
            if (hit.collider.CompareTag("Agua") && triggerBool && !objectInstance || hit.collider.CompareTag("Agua") && rightHandDebugPC && !objectInstance)
            {
                InstaceWater();

            }
            if (hit.collider.CompareTag("Fuego") && triggerBool && !objectInstance || hit.collider.CompareTag("Fuego") && rightHandDebugPC && !objectInstance)
            {
                InstaceFire();

            }
            if (hit.collider.CompareTag("Viento") && triggerBool && !objectInstance || hit.collider.CompareTag("Viento") && rightHandDebugPC && !objectInstance)
            {
                InstanceAir();
            }

        }
        hitPoint = hit.point;
        #endregion
    }

    public void RaycastDrag()
    {
        if (triggerBool || rightHandDebugPC)
        {
            dragging = true;
            if (hit.point == Vector3.zero)
            {
                Vector3 pos = pivotOrigin.position + ray.direction * distance;
                objectInstance.transform.position = pos;
            }
            else if (hit.point != Vector3.zero && hit.collider.gameObject.layer != dragMask)
            {
                objectInstance.transform.position = hit.point;
            }

        }
    }
    #region InstanceObjects
    public void InstanceRock()
    {
        objectInstance = Instantiate(roca, hit.point, Quaternion.identity);
    }

    public void InstaceWater()
    {
        objectInstance = Instantiate(agua, hit.point, Quaternion.identity);
    }
    public void InstaceFire()
    {
        objectInstance = Instantiate(fuego, hit.point, Quaternion.identity);
    }
    public void InstanceAir()
    {
        objectInstance = Instantiate(aire, hit.point, Quaternion.identity);
    }
    #endregion
    public void Launching()
    {
        if (objectInstance != null && dragging)
        {
            if (triggerBool == false || rightHandDebugPC == false)
            {
                Rigidbody selectRb = objectInstance.GetComponent<Rigidbody>();
                selectRb.velocity = ray.direction.normalized * launchVelocity;
                dragging = false;
            }
        }
    }
}
