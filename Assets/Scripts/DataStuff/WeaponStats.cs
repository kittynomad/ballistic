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

    delegate float modifierDelegate(float modifiedVar, float modValue);

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
        List<WeaponModifier> output = new List<WeaponModifier>();
        foreach(WeaponModifier w in wm)
        {
            switch(w.ModType)
            {
                case Enums.Modifiers.multishot:
                    continue;
                case Enums.Modifiers.spread:
                    continue;
                case Enums.Modifiers.damage:
                    continue;
                default:
                    output.Add(w);
                    continue;
            }
        }
        return output;
    }
}
