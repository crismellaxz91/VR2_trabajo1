using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProgressLVL : MonoBehaviour
{
    #region variables
    public GameObject[] specialEnemies;
    public int specialEnemiesLeft;
    public UnityEvent doorEvent; //Entrar a la zona bloqueada para poder desbloquear el domo 1
    public UnityEvent dome1Event;
    //public List<GameObject> hiddenEnemies;
    #endregion
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        specialEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        specialEnemiesLeft = specialEnemies.Length;
    }
     //foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
     //   {
     //       hiddenEnemies.Add(enemy);
     //   }
}
//Añadir script a enemigos ocultos, hacer un array de objetos que tengan este script e indicarle que los GO que tienen ese script son los enemigos especiales

//