using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider bar;
    public Health playerHP;
    public void Start()
    {
        playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        bar = GetComponent<Slider>();
        bar.maxValue = playerHP.health;
    }

    public void Update()
    {
        bar.value = playerHP.health;
    }
}
