/*****************************************************************************
// File Name : Service.cs
// Author : Pierce Nunnelley
// Creation Date : February 13, 2026
//
// Brief Description : This is the class that all other services inherit from.
*****************************************************************************/
using UnityEngine;

public abstract class Service : MonoBehaviour, IInitializable
{
    public virtual async Awaitable Initialize()
    {
        await Awaitable.WaitForSecondsAsync(0.1f);
        Debug.Log(this.GetType().Name + " has finished initializing");
        return;
    }

    public virtual void DeInitialize()
    {
        
    }
}
