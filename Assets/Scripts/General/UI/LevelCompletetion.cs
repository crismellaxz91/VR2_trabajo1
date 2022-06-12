using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelCompletetion : MonoBehaviour
{
    public TMP_Text textoNumeroDeEnemigos;
    public GameObject endMenu;
    public int enemiesLeft;
    //public GameObject winMenu;
    public void Update()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemigos.Length;
        textoNumeroDeEnemigos.text = "Quedan" + " " + enemiesLeft.ToString() + "espíritus";
        //if (enemiesLeft <= 0)
        //{
        //    textoNumeroDeEnemigos.enabled = false;
        //    endMenu.SetActive(true);
        //}
    }
}
