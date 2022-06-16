using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class BossCanvas : MonoBehaviour
{
    public GameObject winUI;
    public Slider bar;
    public GameObject bossName;
    public Health bossHP;
    public Transform canvasPos;
    public ParentConstraint pConstraint;
    void Start()
    {
        bar.maxValue = bossHP.health;
        pConstraint = gameObject.GetComponent<ParentConstraint>();
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
            pConstraint.enabled = false;
            bossName.SetActive(false);
            bar.gameObject.SetActive(false);
            winUI.SetActive(true);
            ToPlayerPos();
        }
    }
    void ToPlayerPos()
    {
        gameObject.transform.position = canvasPos.position;
        gameObject.transform.rotation = canvasPos.rotation;
        Invoke("GameObjPos", 2f);

    }
    void GameObjPos() //para que no siga al player despues de aparecer frente a este.
    {
        gameObject.transform.position = gameObject.transform.localPosition;
        gameObject.transform.rotation = gameObject.transform.localRotation;
    }
}
