using UnityEngine;
using System.Collections;

public class DamageOverTimeStatusEffect : IStatusEffect
{
    private GameObject entity;

    public void OnStartStatus(GameObject effectedEntity)
    {
        entity = effectedEntity;
        Debug.Log("Status added to " + entity.name);
    }

    public bool UpdateStatus()
    {
        Debug.Log("Status affecting " + entity.name);
        return false;
    }

    public void OnCompleteStatus()
    {
        Debug.Log("Status on " + entity.name + " has expired");
    }

}
