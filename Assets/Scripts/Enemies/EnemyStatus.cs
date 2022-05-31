using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStatus : MonoBehaviour
{
    private Health healthScript;
    private NavMeshAgent agent;
    #region VariablesQuemadura
    public List<int> burningTickTimers = new List<int>();
    public int dot = 1;
    public GameObject fireParticles;
    #endregion
    #region variablesCongelacion
    public GameObject icyParticles;
    public List<int> freezingTickTimers = new List<int>();
    #endregion

    public void Start()
    {
        healthScript = GetComponent<Health>();
        agent = GetComponent<NavMeshAgent>();
    }
    #region FuncionesQuemadura
    public void ApplyBurn(int ticks)
    {
        if(burningTickTimers.Count <= 0)
        {
            burningTickTimers.Add(ticks);
            StartCoroutine(Burn());
        }
        else
        {
            burningTickTimers.Add(ticks);
        }
    }
    public IEnumerator Burn()
    {
        while(burningTickTimers.Count > 0)
        {
            fireParticles.SetActive(true);
            for (int i = 0; i < burningTickTimers.Count; i++)
            {
                burningTickTimers[i]--;
            }
            healthScript.health -= dot;
            burningTickTimers.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(0.75f);
            fireParticles.SetActive(false);
        }
    }
    #endregion
    #region FuncionesCongelacion
    public void ApplyFreezing(int ticks)
    {
        if (freezingTickTimers.Count <= 0)
        {
            freezingTickTimers.Add(ticks);
            StartCoroutine(Freeze());
        }
        else
        {
            freezingTickTimers.Add(ticks);
        }
    }
    public IEnumerator Freeze()
    {
        while (freezingTickTimers.Count > 0)
        {
            icyParticles.SetActive(true);
            //MeshRenderer mesh = gameObject.GetComponent<MeshRenderer>();
            for (int i = 0; i < freezingTickTimers.Count; i++)
            {
                freezingTickTimers[i]--;
            }
            agent.speed = 2.3f;
            freezingTickTimers.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(3f);
            icyParticles.SetActive(false);
            agent.speed = 3.5f;
        }
    }
    #endregion
}
