using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RaycastRightHand : MonoBehaviour
{
    #region variables 
    [SerializeField]
    private LayerMask dragMask;

    public Transform player;

    public float distance;

    public float launchVelocity;

    public GameObject roca, agua/*,fuego, viento*/;
    public GameObject selectedObjectR;
    [SerializeField]
    private int maxProjectiles = 0;

    private RaycastHit hit;

    private Ray ray;

    public bool isDragging;

    public float instantiateHeight;
    #endregion
    #region nodesAndInput
    [SerializeField]
    private XRNode xrNode_R = XRNode.RightHand;
    //public List<InputDevice> devices = new List<InputDevice>();
    private InputDevice device_R;
    #endregion
    //Nuevas variables
    public Transform OriginPoint;

    public bool RightHandDebugPC;
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
    }
    public void Update()
    {
        OnEnable();
        bool triggerValue;
        if (device_R.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue || RightHandDebugPC)
        {
            Debug.Log("RightTrigger button is pressed.");
        }
        #region Funcionalidad De instancia de Objetos

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        ray = new Ray(OriginPoint.transform.position, fwd);
        if (RightHandDebugPC || triggerValue)
        {
            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.collider.CompareTag("Tierra") && triggerValue || hit.collider.CompareTag("Tierra") && RightHandDebugPC)
                {
                    if (maxProjectiles < 1)
                    {
                        Instantiate(roca, hit.point, Quaternion.identity);
                        maxProjectiles++;
                    }
                }
                else if (hit.collider.CompareTag("Agua") && triggerValue || hit.collider.CompareTag("Agua") && RightHandDebugPC)
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
                    selectedObjectR = hit.collider.gameObject;
                    isDragging = true;
                }
            }
        }
        if (isDragging)
        {
            Vector3 pos = OriginPoint.position + ray.direction * distance;
            selectedObjectR.transform.position = pos;
        }
        if (!RightHandDebugPC)
        {

            if (selectedObjectR != null && isDragging)
            {
                Rigidbody selectRb = selectedObjectR.GetComponent<Rigidbody>();
                selectRb.velocity = Vector3.forward.normalized * launchVelocity;
            }
            isDragging = false;
            /*Rigidbody selectRb = selectedObjectL.GetComponent<Rigidbody>();
            selectRb.velocity = (fwd - OriginPoint.position).normalized * launchVelocity;*/
            maxProjectiles = 0;
        }
        #endregion
    }
}
