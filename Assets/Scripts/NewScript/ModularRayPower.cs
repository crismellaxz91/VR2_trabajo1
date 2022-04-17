using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ModularRayPower : MonoBehaviour
{
    public Vector3 hitPoint;
    
    public bool triggerBool;

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
        if(leftHandDebugPC) //debug
        {
            triggerBool = true;
        }
        else if(!leftHandDebugPC)
        {
            triggerBool = false;
        }
        OnEnable();

        if (objectInstance != null)
        {
            RaycastDrag();
        }


        if (device_L.TryGetFeatureValue(CommonUsages.triggerButton, out triggerBool) && triggerBool)
        {
            Debug.Log("Triggering");
        }

        #region Ray Start  and Interactions

        ray = new Ray(pivotOrigin.transform.position, pivotOrigin.forward);

        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.CompareTag("Tierra") && triggerBool  && !objectInstance)
            {
                InstanceRock();
            }
            else if (hit.collider.CompareTag("Agua") && triggerBool && !objectInstance)
            {
                InstaceWater();                
            }
        }

        hitPoint = hit.point;
       

        #endregion
    }

    public void RaycastDrag()
    {
        if (triggerBool)
        {

            if (hit.point == Vector3.zero)
            {
                objectInstance.transform.position = hit.point;
            }
            if (hit.point != Vector3.zero && hit.collider.gameObject.layer == dragMask) //( cambiar a != dragMask) si es que no funciona
            {
                Vector3 pos = pivotOrigin.position + ray.direction * distance;
                objectInstance.transform.position = pos;
            }
            //Vector3 pos = pivotOrigin.position + ray.direction * distance; //poner debajo de hit.point == Vector3.zero
            //objectInstance.transform.position = pos;

            //objectInstance.transform.position = hit.point; // poner debajo de hit.point != Vector3.zero && hit.collider.gameObject.layer != dragMask
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
    public void ThrowProjectile()
    {
        if(!triggerBool)
        {
            Rigidbody selectRb = objectInstance.GetComponent<Rigidbody>();
            selectRb.velocity = ray.direction.normalized * launchVelocity;
        }
        objectInstance = null;
    }
}
