using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Raycast : MonoBehaviour
{
    #region variables 
    [SerializeField]
    private LayerMask dragMask;

    public float distance;

    public float launchVelocity;

    public GameObject roca, agua/*,fuego, viento*/;

    public GameObject selectedObjectL;

    [SerializeField]
    private int maxProjectiles = 0;

    private RaycastHit hit;

    private Ray ray;

    public bool isDragging;
    #endregion
    #region nodesAndInput
    [SerializeField]
    private XRNode xrNode_L = XRNode.LeftHand;
    private InputDevice device_L;
    #endregion
    #region Nuevasvariables
    public Transform OriginPoint;
    [SerializeField]
    private GameObject objectInstance;
    
    public float valorTrigger;
    public bool hiting;
    #endregion
    public bool leftHandDebugPC; //debug
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
    }
    public void Update()
    {
        OnEnable();
        float triggerValue;
        if (device_L.TryGetFeatureValue(CommonUsages.trigger, out triggerValue) && triggerValue == 1f || leftHandDebugPC)
        {
            Debug.Log("Trigger values is " + triggerValue);
        }
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (leftHandDebugPC)
        {
            triggerValue = 1f;
        }
        else
        {
            triggerValue = 0f;
        }

        ray = new Ray(OriginPoint.transform.position, fwd);
        if (leftHandDebugPC || triggerValue == 1f)
        {
            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.collider.CompareTag("Tierra") && triggerValue > 0.9f && !objectInstance /*|| hit.collider.CompareTag("Tierra") && leftHandDebugPC*/)
                {
                    if (maxProjectiles < 1)
                    {
                        InstanceRock();
                    }
                }
                else if (hit.collider.CompareTag("Agua") && triggerValue <= 1f && !objectInstance /*|| hit.collider.CompareTag("Agua") && leftHandDebugPC*/)
                {
                    if (maxProjectiles < 1)
                    {
                        InstaceWater();  
                    }
                }


            }
            RaycastDrag();
            if (isDragging && triggerValue == 1)
            {
                if(hit.point != null)
                {
                    Vector3 pos = OriginPoint.transform.position + ray.direction * distance;
                    selectedObjectL.transform.position = pos;
                }
            }
        }
        #region Lanzamiento
        if (!leftHandDebugPC || triggerValue == 0)
        {

            if (selectedObjectL != null && !isDragging)
            {
                Rigidbody selectRb = selectedObjectL.GetComponent<Rigidbody>();
                selectRb.velocity = ray.direction.normalized * launchVelocity;
            }
            isDragging = false;
            objectInstance = null;
            maxProjectiles = 0;
        }
        #endregion
    }
    public void RaycastDrag()
    {
        if (Physics.Raycast(ray, out hit, distance, dragMask))
        {
            if (hit.collider != null)
            {
                selectedObjectL = hit.collider.gameObject;
                isDragging = true;
            }
        }
    }
    public void InstanceRock()
    {
        maxProjectiles++;
        objectInstance = Instantiate(roca, hit.point, Quaternion.identity);
    }
    public void InstaceWater()
    {
        maxProjectiles++;
        objectInstance = Instantiate(agua, hit.point, Quaternion.identity);
    }
}