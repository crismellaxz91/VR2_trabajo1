using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class RaycastLeftHand : MonoBehaviour
{
    #region variables 
    [SerializeField]
    private LayerMask dragMask;

    public Transform player;

    public float distance;

    public float launchVelocity;

    public GameObject roca, agua/*,fuego, viento*/;
    public GameObject selectedObjectL;
    [SerializeField]
    private int maxProjectiles = 0;

    private RaycastHit hit;

    private Ray ray;

    public bool isDragging;

    public float instantiateHeight;
    #endregion
    #region nodesAndInput
    [SerializeField]
    private XRNode xrNode_L = XRNode.LeftHand;
    //public List<InputDevice> devices = new List<InputDevice>();
    private InputDevice device_L;
    #endregion
    //Nuevas variables
    public Transform OriginPoint;
    public GameObject rocaInstance;
    public bool hiting;

    public bool leftHandDebugPC;
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
         
        #region Funcionalidad De instancia de Objetos
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if(leftHandDebugPC)
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
                if (hit.collider.CompareTag("Tierra") && triggerValue > 0.9f && !rocaInstance /*|| hit.collider.CompareTag("Tierra") && leftHandDebugPC*/)
                {
                    if (maxProjectiles < 1)
                    {
                        rocaInstance = Instantiate(roca, hit.point, Quaternion.identity);
                        hiting = true;

                        maxProjectiles++;

                        if (isDragging && triggerValue == 1 && hit.point == null)
                        {
                            Vector3 pos = OriginPoint.position + ray.direction * distance;
                            selectedObjectL.transform.position = pos;
                        }
                    }
                }
                else if (hit.collider.CompareTag("Agua") && triggerValue <= 1f || hit.collider.CompareTag("Agua") && leftHandDebugPC)
                {
                    if (maxProjectiles < 1)
                    {
                        Instantiate(agua, hit.point /*+ Vector3.up * (instantiateHeight)*/, Quaternion.identity);
                        maxProjectiles++;
                    }
                }

                
            }
            if (Physics.Raycast(ray, out hit, distance, dragMask))
            {
                if (hit.collider != null)
                {
                    selectedObjectL = hit.collider.gameObject;
                    isDragging = true;
                }
            }
        }
        if (isDragging && triggerValue == 1)
        {
            
            Vector3 pos = OriginPoint.position + ray.direction * distance;
            selectedObjectL.transform.position = pos;
           
        }
        if (!leftHandDebugPC || triggerValue == 0)
        {
    
            if(selectedObjectL != null && !isDragging)
            {
                Rigidbody selectRb = selectedObjectL.GetComponent<Rigidbody>();
                selectRb.velocity = ray.direction.normalized * launchVelocity;
            }
            isDragging = false;
            /*Rigidbody selectRb = selectedObjectL.GetComponent<Rigidbody>();
            selectRb.velocity = (fwd - OriginPoint.position).normalized * launchVelocity;*/
            maxProjectiles = 0;
        }
        #endregion
    }
}
