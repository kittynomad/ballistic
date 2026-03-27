/*****************************************************************************
// File Name : WeaponStats.cs
// Author : Pierce Nunnelley
// Creation Date : March 3, 2026
//
// Brief Description : WeaponStats is a data type made with the purpose of
// storing the "final" stats of a constructed weapon, AKA the data used when
// actually firing. For the parts used in a constructed weapon, see 
// WeaponConfig.
*****************************************************************************/
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
    private float timeBetweenShots;
    private float batteryCapacity;
    private float batteryChargeRate;
    private bool autoFire;

    private List<WeaponModifier> effects;

    delegate float modifierDelegate(float modifiedVar, float modValue);

    public float BaseDamage { get => baseDamage; set => baseDamage = value; }
    public float Spread { get => spread; set => spread = value; }
    public float Multishot { get => multishot; set => multishot = value; }
    public float ReloadTime { get => reloadTime; set => reloadTime = value; }
    public float EnergyCost { get => energyCost; set => energyCost = value; }
    public int MagSize { get => magSize; set => magSize = value; }
    public float StartVelocity { get => startVelocity; set => startVelocity = value; }
    public bool AutoFire { get => autoFire; set => autoFire = value; }
    public float TimeBetweenShots { get => timeBetweenShots; set => timeBetweenShots = value; }
    public float BatteryCapacity { get => batteryCapacity; set => batteryCapacity = value; }
    public float BatteryChargeRate { get => batteryChargeRate; set => batteryChargeRate = value; }
    public List<WeaponModifier> Effects { get => effects; set => effects = value; }

    public WeaponStats(string name)
    {
        baseDamage = 0;
        spread = 0f;
        multishot = 0f;
        reloadTime = 0f;
        energyCost = 0;
        magSize = 0;
        startVelocity = 1;
        autoFire = false;
        effects = new List<WeaponModifier>();
        timeBetweenShots = 0.5f;
        batteryCapacity = 1f;
        batteryChargeRate = 1f;
    }

    public void ApplyNonModifiers(WeaponConfig w)
    {
        baseDamage = w.Magazine.Damage;
        spread = w.Muzzle.Spread;
        multishot = 1f;
        reloadTime = w.Magazine.ReloadTime;
        magSize = w.Magazine.MagSize;
        startVelocity = w.Frame.FireVelocity;
        energyCost = w.Frame.EnergyCost + w.Magazine.EnergyCost + w.Muzzle.EnergyCost;
        autoFire = w.Magazine.AutomaticFire;
        timeBetweenShots = w.Magazine.TimeBetweenShots;
        batteryCapacity = w.Battery.Capacity;
        batteryChargeRate = w.Battery.RechargeRate;
    }

    public void ApplyModifiers(WeaponConfig w)
    {
        if (effects == null)
            effects = new List<WeaponModifier>();

        effects.AddRange(w.Frame.Modifiers);
        effects.AddRange(w.Battery.Modifiers);
        effects.AddRange(w.Magazine.Modifiers);
        effects.AddRange(w.Muzzle.Modifiers);

        foreach(WeaponAddon addon in w.Addons)
        {
            if(addon != null)
            {
                effects.AddRange(addon.Modifiers);
                energyCost += addon.EnergyCost;
            }
        }

        effects = ApplyPrefireModifiers(Effects);
    }

    public List<WeaponModifier> ApplyPrefireModifiers(List<WeaponModifier> wm)
    {
        List<WeaponModifier> output = new List<WeaponModifier>();
        foreach(WeaponModifier w in wm)
        {
            modifierDelegate m = OperationFromEnum(w.ModOperator);
            switch(w.ModType)
            {
                case Enums.Modifiers.multishot:
                    multishot = m(multishot, w.ModStrength);
                    continue;
                case Enums.Modifiers.spread:
                    spread = m(spread, w.ModStrength);
                    continue;
                case Enums.Modifiers.damage:
                    baseDamage = m(baseDamage, w.ModStrength);
                    continue;
                case Enums.Modifiers.velocity:
                    startVelocity = m(startVelocity, w.ModStrength);
                    continue;
                case Enums.Modifiers.cooldown:
                    timeBetweenShots = m(startVelocity, w.ModStrength);
                    continue;
                default:
                    output.Add(w);
                    continue;
            }
        }
        return output;
    }

    private modifierDelegate OperationFromEnum(Enums.Operators op)
    {
        switch(op)
        {
            case Enums.Operators.add:
                return HelperFunctions.Add;
            case Enums.Operators.subtract:
                return HelperFunctions.Subtract;
            case Enums.Operators.multiply:
                return HelperFunctions.Multiply;
            case Enums.Operators.divide:
                return HelperFunctions.Divide;
            default:
                return null;
        }
    }

    public override string ToString()
    {
        string output = "\nWEAPON STATS\n-----------";
        output += "\ndamage: " + baseDamage;
        output += "\nspread: " + spread;
        output += "\nmultishot: " + multishot;
        output += "\nreloadTime: " + reloadTime;
        output += "\nenergyCost: " + energyCost;
        output += "\nmagSize: " + magSize;
        output += "\nstartVelocity: " + startVelocity;
        output += "\nTime between shots: " + timeBetweenShots;
        output += "\nauto fires: " + autoFire;
        output += "\n-----------\nMODIFIERS\n-----------";
        foreach (WeaponModifier wm in Effects)
        {
            output += "\n" + wm.ModType + " " + wm.ModOperator + " " + wm.ModStrength;
        }
        
        return output;
    }
}
