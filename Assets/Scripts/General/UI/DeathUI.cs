using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathUI : MonoBehaviour
{
    public GameObject deathUI;
    public Transform player;
    public GameObject bar;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {   
        if(player = null)
        {
            bar.SetActive(false);
            deathUI.SetActive(true);
        }
    }
}
