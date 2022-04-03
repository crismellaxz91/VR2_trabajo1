using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EarthBending : MonoBehaviour
{
    public bool Held;
    public Transform holdPosition;
    public Rigidbody rb;
    public float speed;
    public @XRIDefaultInputActions inputActions;
    public bool fireIsPressed;

    public void OnEnable()
    {
        inputActions.Custom.Hold.performed += Holding;
    }
    public void OnDisable()
    {
        inputActions.Custom.Hold.performed -= Holding;
    }
    public void Start()
    {
        holdPosition = GameObject.FindGameObjectWithTag("Position").GetComponent<Transform>();
    }
    public void Holding(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            gameObject.transform.position = holdPosition.position;
        }
        else
        {
            Debug.Log("soltado");
        }
    }
    void Update()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
}
