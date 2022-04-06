using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Raycast : MonoBehaviour
{
#region variables 
    public float distance;
    public GameObject roca, agua/*,fuego, viento*/;
    [SerializeField]
    private int maxProjectiles;
    private RaycastHit hit;
   /* private Ray ray;*/
    public Vector3 endPoint;
    public bool instantiated;
    public float followSpeed;
    public float instantiateHeight;
    #endregion
    #region nodesAndInput
    [SerializeField]
    private XRNode xrNode_L = XRNode.LeftHand;
    [SerializeField]
    private XRNode xrNode_R = XRNode.RightHand; 
    //public List<InputDevice> devices = new List<InputDevice>();
    private InputDevice device_L;
    private InputDevice device_R;
    #endregion
    //Nuevas variables
    public Transform OriginPoint;

    public bool rightHandDebugPC;
    public bool lefttHandDebugPC;

    public void Start()
    {
        /*ray = new Ray(transform.position, transform.forward);*/
        
    }

    void GetDevice()
    {
        device_L = InputDevices.GetDeviceAtXRNode(xrNode_L);
        device_R = InputDevices.GetDeviceAtXRNode(xrNode_R);


        //InputDevices.GetDevicesAtXRNode(xrNode, devices);
        //device = devices.FirstOrDefault();
    }

    private void OnEnable()
    {
        if (!device_L.isValid)
        {
            GetDevice();
        }

        if (!device_R.isValid)
        {
            GetDevice();
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 end = gameObject.transform.position + ray.direction * distance;*/
        OnEnable();
        bool triggerValue;
        if (device_L.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue || lefttHandDebugPC)
        {
            Debug.Log("Trigger button is pressed.");
        }

        bool triggerValue_R;
        if (device_R.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue_R) && triggerValue_R || rightHandDebugPC)
        {
            Debug.Log("Right Trigger button is pressed.");
        }

        #region Funcionalidad De instancia de Objetos

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(OriginPoint.position, fwd, out hit, distance))
        {
            endPoint = hit.point;

            if (hit.collider.CompareTag("Tierra") && triggerValue_R || hit.collider.CompareTag("Tierra") && triggerValue || hit.collider.CompareTag("Tierra") && rightHandDebugPC)
            {
                if(maxProjectiles < 2)
                {
                    Instantiate(roca, hit.point, Quaternion.identity);
                    maxProjectiles++;

                }
               /* Instantiate(roca, hit.point, Quaternion.identity);*/
                /*Debug.Log(hit.transform.position);*/


            }
            else if (hit.collider.CompareTag("Agua") && triggerValue_R || hit.collider.CompareTag("Agua") && triggerValue || hit.collider.CompareTag("Agua") && lefttHandDebugPC)
            {
                if (maxProjectiles < 2)
                {
                    Instantiate(agua, hit.point, Quaternion.identity);
                    maxProjectiles++;
                }
              /*Instantiate(agua, hit.point, Quaternion.identity);*/
                Debug.Log(hit.transform.position);

            }
        }
        else
        {
            Debug.Log("Nothing hit");
            /* Debug.Log(hit.transform.position);*/
            endPoint = OriginPoint.position + (fwd.normalized * distance);
        }


        
        #endregion
    }
}