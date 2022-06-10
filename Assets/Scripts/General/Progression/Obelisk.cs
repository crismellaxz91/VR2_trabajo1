using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obelisk : MonoBehaviour
{
    public ProgressLVL progress;
    public void OnDestroy()
    {
        progress.dome1Event.Invoke();
    }
}
