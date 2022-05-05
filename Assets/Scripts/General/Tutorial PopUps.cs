using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TutorialPopUps : MonoBehaviour
{
    public GameObject [] popUps;
    private int popUpIndex;
    private XRNode xrNode_L = XRNode.LeftHand;
    private InputDevice device_L;

    //void Update()
    //{
    //    for (int i = 0; i < popUps.length; i++)
    //    {
    //        if(i == popUpIndex)
    //        {
    //            popUps[popUpIndex].SetActive(true);
    //        }
    //        else
    //        {
    //            popUps[popUpIndex].SetActive(false);
    //        }
    //    }
    //    if(popUpIndex == 0)
    //    {

    //    }
    //}
}
