using UnityEngine;
using System.Collections;

public class DamageOverTimeStatusEffect : IStatusEffect
{
    private GameObject entity;
    private float duration = 10f;

    public void OnStartStatus(GameObject effectedEntity)
    {
        entity = effectedEntity;
        Debug.Log("Status added to " + entity.name);
    }

    public bool UpdateStatus()
    {
        Debug.Log("Status affecting " + entity.name);
        duration -= Time.deltaTime;
        return duration <= 0f;
    }

    public void OnCompleteStatus()
    {
        Debug.Log("Status on " + entity.name + " has expired");
    }

}
