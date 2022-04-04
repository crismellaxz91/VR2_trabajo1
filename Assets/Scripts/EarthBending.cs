using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EarthBending : MonoBehaviour
{
    public Transform holdPosition;
    public Rigidbody rb;
    public float throwSpeed;
    public @XRIDefaultInputActions inputActions;

    public void Start()
    {
        holdPosition = GameObject.FindGameObjectWithTag("Position").GetComponent<Transform>();
    }
    public void Holding(InputAction.CallbackContext context)
    {
       switch(context.phase)
        {
            case InputActionPhase.Performed:
                Debug.Log("Performed");
                break;
            case InputActionPhase.Started:
                Debug.Log("Started");
                break;
            case InputActionPhase.Canceled:
                Debug.Log("Started");
                break;
        }
    }
    void Update()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        gameObject.transform.position = holdPosition.position;
    }
}
