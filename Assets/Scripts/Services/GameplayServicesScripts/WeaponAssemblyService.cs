/*****************************************************************************
// File Name : WeaponAssemblyService.cs
// Author : Pierce Nunnelley
// Creation Date : February 15, 2026
//
// Brief Description : This service handles the assembly of weapon components
// into a single, functional weapon.
*****************************************************************************/
using UnityEngine;
using NaughtyAttributes;

public class WeaponAssemblyService : Service
{
    [Button]
    public Weapon AssembleWeapon()
    {
        Weapon output = AssembleWeapon(ComponentDataService.Instance.DefaultWeaponConfig());
        return output;
    }
    public Weapon AssembleWeapon(WeaponConfig parts)
    {
        Weapon w = FindAnyObjectByType<PlayerBehaviors>().gameObject.AddComponent(typeof(Weapon)) as Weapon;
        w.Initialize();
        w.Config = parts;

        WeaponStats stats = new WeaponStats();

        stats.ApplyNonModifiers(parts);
        stats.ApplyModifiers(parts);

        w.Stats = stats;
        print(w);
        return w;
    }
}
