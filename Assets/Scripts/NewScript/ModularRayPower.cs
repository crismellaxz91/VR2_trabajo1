using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ModularRayPower : MonoBehaviour
{
    public Vector3 hitPoint;
    
    public bool triggerBool;

    public bool dragging;

    private Ray ray;
    private RaycastHit hit;
    public LayerMask dragMask;
    public float distance;

    public GameObject roca;
    public GameObject agua;
    public GameObject objectInstance;
    public float launchVelocity;

    [Header("Transforms")]
    public Transform pivotOrigin;

    //public Transform objectHold;
    //objectHold.position = pivotOrigin.position + ray.direction * distance;

    public bool leftHandDebugPC; //debug

    #region nodesAndInput
    [SerializeField]
    private XRNode xrNode_L = XRNode.LeftHand;
    private InputDevice device_L;


    void GetDevice()
    {
        device_L = InputDevices.GetDeviceAtXRNode(xrNode_L);
    }
    private void OnEnable()
    {
        if (!device_L.isValid)
        {
            GetDevice();
        }
        else if(leftHandDebugPC)
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

        if(!dragging)
        {
            objectInstance = null;
        }

        Launching();

        if (device_L.TryGetFeatureValue(CommonUsages.triggerButton, out triggerBool) && triggerBool)
        {
            Debug.Log("Triggering");
        }

        #region Ray Start  and Interactions

        ray = new Ray(pivotOrigin.transform.position, pivotOrigin.forward);

        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.CompareTag("Tierra") && triggerBool  && !objectInstance || hit.collider.CompareTag("Tierra") && leftHandDebugPC && !objectInstance)
            {
                InstanceRock();

            }
            else if (hit.collider.CompareTag("Agua") && triggerBool && !objectInstance || hit.collider.CompareTag("Agua") && leftHandDebugPC && !objectInstance)
            {
                InstaceWater();
                
            }
        }
        hitPoint = hit.point;
        #endregion
    }

    public void RaycastDrag()
    {
        if (triggerBool || leftHandDebugPC)
        {
            dragging = true;
            if (hit.point == Vector3.zero)
            {
                Vector3 pos = pivotOrigin.position + ray.direction * distance;
                objectInstance.transform.position = pos;
            }
            else if(hit.point != Vector3.zero && hit.collider.gameObject.layer != dragMask)
            {
                objectInstance.transform.position = hit.point;
            }
            
        }
    }
    public void InstanceRock()
    {
        objectInstance = Instantiate(roca, hit.point, Quaternion.identity);
    }

    public void InstaceWater()
    {    
        objectInstance = Instantiate(agua, hit.point, Quaternion.identity);
    }
    //public void InstaceFire()
    //{
    //    objectInstance = Instantiate(fuego, hit.point, Quaternion.identity);
    //}
    public void Launching()
    {
        if(objectInstance != null && dragging)
        {
            if (triggerBool == false || leftHandDebugPC == false)
            {
                Rigidbody selectRb = objectInstance.GetComponent<Rigidbody>();
                selectRb.velocity = ray.direction.normalized * launchVelocity;
                dragging = false;
            }
        }
    }
}
