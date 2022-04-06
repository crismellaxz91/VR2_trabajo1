using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Raycast : MonoBehaviour
{
    public float distance;
    public GameObject roca, agua/*,fuego, viento*/;
    private RaycastHit hit;
    public bool instantiated;
    public bool isPressed;

    [SerializeField]
    private XRNode xrNode_L = XRNode.LeftHand;
    [SerializeField]
    private XRNode xrNode_R = XRNode.RightHand; 
    //public List<InputDevice> devices = new List<InputDevice>();
    private InputDevice device_L;
    private InputDevice device_R;


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

        OnEnable();

        bool triggerValue;
        if (device_L.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            Debug.Log("Trigger button is pressed.");
        }

        bool triggerValue_R;
        if (device_R.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue_R) && triggerValue_R)
        {
            Debug.Log("Right Trigger button is pressed.");
        }
        var fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, distance))
        {
            if (hit.collider.CompareTag("Tierra") && triggerValue_R || hit.collider.CompareTag("Tierra") && triggerValue)
            {
                Instantiate(roca, hit.point, Quaternion.identity);

            }
            else if (hit.collider.CompareTag("Agua") && triggerValue_R || hit.collider.CompareTag("Agua") && triggerValue)
            {
                Instantiate(agua, hit.point, Quaternion.identity);

            }
        }
        else
        {
            Debug.Log("Nothing hit");
        }
    }
}