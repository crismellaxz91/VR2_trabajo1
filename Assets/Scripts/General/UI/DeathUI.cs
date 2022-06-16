using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            OnDeath();
            deathUI.SetActive(true);
            popUps.SetActive(false);
            bar.SetActive(false);
        }
        #endregion
        //OnDeath();
    }
    public void OnDeath()
    {
        canvas.transform.position = canvasPos.position;
        canvas.transform.rotation = canvasPos.localRotation;
        Invoke("StopFollowing", 2f);
    }
    public void StopFollowing ()
    {
        canvas.transform.position = canvas.transform.localPosition;
        canvas.transform.rotation = canvas.transform.localRotation;
    }
}
