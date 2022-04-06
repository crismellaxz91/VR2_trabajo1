using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*using UnityEngine.XR;*/
using UnityEngine.InputSystem;
using System.Linq;


public class raycastToSpawn : MonoBehaviour
{
    /*[SerializeField]
    private XRNode xrNode_L = XRNode.LeftHand;
    [SerializeField]
    private XRNode xrNode_R = XRNode.RightHand;
     private InputDevice device_L;
     private InputDevice device_R;*/
    #region variables
    public float distance;
    public GameObject roca, agua/*,fuego, viento*/;
    public @XRIDefaultInputActions inputActions;
    private RaycastHit hit;
    [SerializeField]
    private float instantiateHeight;
    public bool instantiated;
    /*public Transform holdPos;*/
    #endregion
    void Awake()
    {
       inputActions = new @XRIDefaultInputActions();
    }
   /*void GetDevice()
    {
      device_L = InputDevices.GetDeviceAtXRNode(xrNode_L);
        device_R = InputDevices.GetDeviceAtXRNode(xrNode_R);
        //InputDevices.GetDevicesAtXRNode(xrNode, devices);
        //device = devices.FirstOrDefault();
    }*/
    private void OnEnable()
    {
       /* if (!device_L.isValid)
        {
            GetDevice();
        }

        if (!device_R.isValid)
        {
            GetDevice();
        }*/
        #region inputBending
        inputActions.XRILeftHandInteraction.Fire.performed += Bending;
        inputActions.XRILeftHandInteraction.Fire.Enable();
        inputActions.XRIRightHandInteraction.Fire.performed += Bending;
        inputActions.XRIRightHandInteraction.Fire.Enable();
        #endregion
    }
   /* void Update()
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

    }*/
     private void OnDisable()
     {

         inputActions.XRILeftHandInteraction.Fire.performed -= Bending;
         inputActions.XRIRightHandInteraction.Fire.performed -= Bending;
     }
      public void Bending(InputAction.CallbackContext context)
      {
          var fwd = transform.TransformDirection(Vector3.forward);
          if (Physics.Raycast(transform.position, fwd, out hit, distance))
          {
              if (hit.collider.CompareTag("Tierra"))
              {
                  Instantiate(roca, hit.point + Vector3.up * instantiateHeight, Quaternion.identity);
              }
              else if(hit.collider.CompareTag("Agua"))
              {
                  Instantiate(agua, hit.point + Vector3.up * instantiateHeight, Quaternion.identity);
              }
          }
         /* else
          {
              Debug.Log("Nothing hit");
          }*/
      }
}
