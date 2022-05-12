using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCompletetion : MonoBehaviour
{
    public TMP_Text tMP_Text;
    public TMP_Text youWin;
    public int enemiesLeft;
    public GameObject tutorial;
    public void Update()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemigos.Length;
        tMP_Text.text = "Quedan" + " " + enemiesLeft.ToString() + "espíritus";
        if (enemiesLeft == 0)
        {
            tMP_Text.enabled = false;
            youWin.enabled = true;
        }
    }
}
