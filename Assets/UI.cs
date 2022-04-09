using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    /* public TMP_Text text;
     public Health playerHP;
     public void Update()
     {
         if(playerHP != null)
         {
             text.text = playerHP.health.ToString();
         }
         else
         {
             Debug.Log("The player died");
         }
     }*/
    public TMP_Text tMP_Text;
    public int enemiesLeft;
    public void Update()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemigos.Length;
        tMP_Text.text = "Enemigos:" + " "+ enemiesLeft.ToString();
    }
}
