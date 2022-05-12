using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class TutorialPopUps : MonoBehaviour
{
    #region variables
    public GameObject[] popUps;
    [SerializeField]
    private int popUpIndex;
    [SerializeField]
    private Vector2 primaryAxisValue;
    public float waitTime;
    #endregion
    #region NodesAndInput
    private XRNode xrNode_L = XRNode.LeftHand;
    private InputDevice device_L;
    private XRNode xrNode_R = XRNode.RightHand;
    private InputDevice device_R;

    #region debug
    public bool triggerBool;
    public bool triggerLDebugPC;
    public bool triggerRDebugPC;
    public bool gripDebugPC;
    #endregion

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
        else if (triggerLDebugPC)
        {
            GetDeviceL();
        }
        else if (triggerRDebugPC)
        {
            GetDeviceR();
        }
    }
    #endregion
    void Update()
    {
        OnEnable();
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[popUpIndex].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }
         //Tutorial movimiento de personaje y camara

        if (popUpIndex == 0)
        {
            if (device_L.TryGetFeatureValue(CommonUsages.primary2DAxis, out primaryAxisValue) && primaryAxisValue != Vector2.zero)
            {
                popUpIndex++;
            }
        }
         //Tutorial invocarElementos
        else if (popUpIndex == 1)
        {
            if (device_L.TryGetFeatureValue(CommonUsages.triggerButton, out triggerBool) && triggerBool || device_R.TryGetFeatureValue(CommonUsages.triggerButton, out triggerBool) && triggerBool || triggerRDebugPC || triggerLDebugPC)
            {
                popUpIndex++;
            }
        } 
        //Tutorial agarre
        else if (popUpIndex == 2)
        {
            if (device_L.TryGetFeatureValue(CommonUsages.gripButton, out triggerBool) && triggerBool || gripDebugPC)
            {
                popUpIndex++;
            }
        }
        //Indicacion de lo que debes hacer ahora.
        else if (popUpIndex == 3)
        {
            if (device_L.TryGetFeatureValue(CommonUsages.primary2DAxis, out primaryAxisValue) && primaryAxisValue != Vector2.zero)
            {
                popUpIndex++;
            }
        }
    }
}
