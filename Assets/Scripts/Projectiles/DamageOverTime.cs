using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    private Health healthScript;
    public List<int> burnTickTimers = new List<int>();
    public int dot = 1;
    public GameObject fireParticles;
    public void Start()
    {
        healthScript = GetComponent<Health>();
    }
    public void ApplyBurn(int ticks)
    {
        if(burnTickTimers.Count <= 0)
        {
            burnTickTimers.Add(ticks);
            StartCoroutine(Burn());
        }
        else
        {
            burnTickTimers.Add(ticks);
        }
    }
    public IEnumerator Burn()
    {
        while(burnTickTimers.Count > 0)
        {
            fireParticles.SetActive(true);
            for (int i = 0; i < burnTickTimers.Count; i++)
            {
                burnTickTimers[i]--;
            }
            healthScript.health -= dot;
            burnTickTimers.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(0.75f);
            fireParticles.SetActive(false);
        }
    }
}
