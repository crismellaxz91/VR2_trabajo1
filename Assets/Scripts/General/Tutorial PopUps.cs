using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TutorialPopUps : MonoBehaviour
{
    #region variables
    public GameObject[] popUps;
    private int popUpIndex;
    public float waitTime;
    #endregion
    #region NodesAndInput
    private XRNode xrNode_L = XRNode.LeftHand;
    private InputDevice device_L;
    private XRNode xrNode_R = XRNode.RightHand;
    private InputDevice device_R;
    public bool moveBool;
    public bool triggerBool;
    public bool leftHandDebugPC;
    public bool rightHandDebugPC;
    void GetDeviceL()
    {
        device_L = InputDevices.GetDeviceAtXRNode(xrNode_L);
    }
    void GetDeviceR()
    {
        device_R = InputDevices.GetDeviceAtXRNode(xrNode_R);
    }
    private void OnEnable()
    {
        if (!device_L.isValid)
        {
            GetDeviceL();
        }
        if (!device_R.isValid)
        {
            GetDeviceR();
        }
        else if (leftHandDebugPC)
        {
            GetDeviceL();
        }
        else if (rightHandDebugPC)
        {
            GetDeviceR();
        }
    }
    #endregion
    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[popUpIndex].SetActive(true);
            }
            else
            {
                popUps[popUpIndex].SetActive(false);
            }
        }
        if (popUpIndex == 0)
        {
            if (device_L.TryGetFeatureValue(CommonUsages.triggerButton, out moveBool) && moveBool /*||*/ )
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            if (device_L.TryGetFeatureValue(CommonUsages.triggerButton, out triggerBool) && triggerBool)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            if (device_L.TryGetFeatureValue(CommonUsages.gripButton, out triggerBool) && triggerBool)
            {
                popUpIndex++;
            }
        }
    }
}
