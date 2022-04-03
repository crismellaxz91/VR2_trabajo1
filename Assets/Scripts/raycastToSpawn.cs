using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class raycastToSpawn : MonoBehaviour
{
    public float distance;
    public GameObject roca;
    public GameObject agua;
    /*public GameObject fuego;*/
   /* public GameObject viento;*/
    public @XRIDefaultInputActions inputActions;
    private RaycastHit hit;
    void Awake()
    {
        inputActions = new @XRIDefaultInputActions();
    }
    private void OnEnable()
    {
        inputActions.Custom.Bending.performed += Bending;
        inputActions.Custom.Enable();
    }
    private void OnDisable()
    {
        inputActions.Custom.Bending.performed -= Bending;
        
    }
    public void Bending(InputAction.CallbackContext context)
    {
        var fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, distance))
        {
            if (hit.collider.CompareTag("Tierra"))
            {
                Instantiate(roca, hit.point, Quaternion.identity);
            }
            else if(hit.collider.CompareTag("Agua"))
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