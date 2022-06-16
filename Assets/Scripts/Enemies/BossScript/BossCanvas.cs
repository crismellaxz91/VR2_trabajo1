using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossCanvas : MonoBehaviour
{
    public GameObject winUI;
    public Slider bar;
    public GameObject bossName;
    public Health bossHP;
    void Start()
    {
        bar.maxValue = bossHP.health;
    }

    // Update is called once per frame
    void Update()
    {
        bar.value = bossHP.health;
        BossDead();
    }
    void BossDead()
    {
        if(bossHP.health <= 0)
        {
            bossName.SetActive(false);
            bar.gameObject.SetActive(false);
            winUI.SetActive(true);
        }
    }
}
