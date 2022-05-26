using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathUI : MonoBehaviour
{
    #region ObjetosParaActivarYDesactivar
    public GameObject deathUI; //UI cuando Mueres
    public GameObject player;
    public GameObject bar;
    public GameObject popUps;
    public Transform canvasPos;
    public GameObject canvas;
    #endregion
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        canvas = GameObject.FindGameObjectWithTag("child");
    }
    void Update()
    {
        #region Chequear Si El Player Sigue Vivo
        Health playerHp = player.gameObject.GetComponent<Health>();
        if(playerHp.health <= 0)
        {
            deathUI.SetActive(true);
            popUps.SetActive(false);
            bar.SetActive(false);
        }
        #endregion
        CanvasFollow();
    }
    public void CanvasFollow() //sigue la posicion de un objeto que lleva el player.
    {
        canvas.transform.position = canvasPos.transform.position;
        canvas.transform.rotation = canvasPos.transform.rotation;
    }
}
