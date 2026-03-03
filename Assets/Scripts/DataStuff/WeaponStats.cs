using UnityEngine;
using System.Collections.Generic;

public struct WeaponStats
{
    private float baseDamage;
    private float spread;
    private float multishot;
    private float reloadTime;
    private float energyCost;
    private int magSize;
    private float startVelocity;

    private List<WeaponModifier> effects;

    public WeaponStats(WeaponFrame f)
    {
        baseDamage = 0f;
        spread = 0f;
        multishot = 0f;
        reloadTime = 0f;
        energyCost = f.EnergyCost;
        magSize = 0;
        startVelocity = f.FireVelocity;
        effects = f.Modifiers;
    }

    public List<WeaponModifier> ApplyPrefireModifiers(List<WeaponModifier> wm)
    {
        return wm;
    }
}
