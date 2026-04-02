using System.Collections.Generic;
using UnityEngine;

public abstract class StackableStatusEffect : IStatusEffect
{
    private List<float> durations = new List<float>();
    private List<float> strengths = new List<float>();
    private ShootableEntity target;

    private bool durationsRunSimultaneously = false;

    public ShootableEntity Target { get => target; set => target = value; }
    public List<float> Strengths { get => strengths; set => strengths = value; }
    public List<float> Durations { get => durations; set => durations = value; }

    public abstract Sprite GetIcon();

    public abstract void OnCompleteStatus();

    public virtual void OnNewStack(float strength)
    {
        strengths.Add(strength);
        durations.Add(strength);
        Debug.Log("Stack added\n" + strengths.Count);
    }

    public virtual void OnStartStatus(ShootableEntity effectedEntity, float strength)
    {
        target = effectedEntity;
        OnNewStack(strength);
    }

    public virtual bool UpdateStatus()
    {
        if(durationsRunSimultaneously)
        {
            for(int i = 0; i < durations.Count; i++)
            {
                durations[i] -= Time.deltaTime;
                if(durations[i] <= 0f)
                {
                    RemoveStack(i);
                }
            }
        }
        else
        {
            Debug.Log(durations.Count);
            durations[0] -= Time.deltaTime;
            if (durations[0] <= 0f)
            {
                RemoveStack(0);
            }
        }

        return durations.Count <= 0;
    }

    public virtual void RemoveStack(int index)
    {
        strengths.RemoveAt(index);
        durations.RemoveAt(index);
    }

}
