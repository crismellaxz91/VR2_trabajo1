using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProgressLVL : MonoBehaviour
{
    #region variables
    public List<GameObject> specialEnemies;
    public int specialEnemiesLeft;
    public UnityEvent doorEvent; //Entrar a la zona bloqueada para poder desbloquear el domo 1
    public UnityEvent dome1Event;
    public UnityEvent endingEvent;
    //public List<GameObject> hiddenEnemies;
    #endregion
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(specialEnemies.Count == 0)
        {
            doorEvent.Invoke();
        }
    }
}