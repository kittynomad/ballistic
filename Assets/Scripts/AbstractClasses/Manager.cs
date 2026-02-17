/*****************************************************************************
// File Name : Service.cs
// Author : Pierce Nunnelley
// Creation Date : February 11, 2026
//
// Brief Description : This is the class that all other managers inherit from.
*****************************************************************************/
using UnityEngine;
using System.Collections.Generic;

public abstract class Manager : MonoBehaviour, IInitializable
{
    public List<Service> ServiceReferences;
    public List<Service> ServiceInstances;


    public virtual async Awaitable Initialize()
    {
        
        foreach (var service in ServiceReferences)
        {
            if (!destroyCancellationToken.IsCancellationRequested)
            {
                var s = Instantiate(service, transform);

                ServiceInstances.Add(s);

                await s.Initialize();
            }

        }
        Debug.Log(this.GetType().Name + " has finished initializing");
    }

    public virtual void DeInitialize()
    {
        
    }

}
