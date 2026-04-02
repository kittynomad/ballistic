using System.Collections.Generic;
using UnityEngine;

public abstract class StackableStatusEffect : IStatusEffect
{
    private List<float> durations;
    private List<float> strengths;
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
    }

    public virtual void OnStartStatus(ShootableEntity effectedEntity, float strength)
    {
        target = effectedEntity;
    }

    public virtual bool UpdateStatus()
    {
        if(durationsRunSimultaneously)
        {
            for(int i = 0; i < durations.Capacity; i++)
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
            durations[0] -= Time.deltaTime;
            if (durations[0] <= 0f)
            {
                RemoveStack(0);
            }
        }

        return durations.Capacity <= 0;
    }

    public virtual void RemoveStack(int index)
    {
        strengths.RemoveAt(index);
        durations.RemoveAt(index);
    }

}
