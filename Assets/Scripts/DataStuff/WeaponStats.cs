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

    private List<WeaponModifier> effects;

    delegate float modifierDelegate(float modifiedVar, float modValue);

    public float BaseDamage { get => baseDamage; set => baseDamage = value; }
    public float Spread { get => spread; set => spread = value; }
    public float Multishot { get => multishot; set => multishot = value; }
    public float ReloadTime { get => reloadTime; set => reloadTime = value; }
    public float EnergyCost { get => energyCost; set => energyCost = value; }
    public int MagSize { get => magSize; set => magSize = value; }
    public float StartVelocity { get => startVelocity; set => startVelocity = value; }

    public WeaponStats(string name)
    {
        baseDamage = 0;
        spread = 0f;
        multishot = 0f;
        reloadTime = 0f;
        energyCost = 0;
        magSize = 0;
        startVelocity = 1;
        effects = new List<WeaponModifier>();
    }

    public void ApplyNonModifiers(WeaponConfig w)
    {
        baseDamage = w.Magazine.Damage;
        spread = w.Muzzle.Spread;
        //multishot = 0f;
        reloadTime = w.Magazine.ReloadTime;
        magSize = w.Magazine.MagSize;
        startVelocity = w.Frame.FireVelocity;
        energyCost = w.Frame.EnergyCost + w.Magazine.EnergyCost + w.Muzzle.EnergyCost;
        
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
            effects.AddRange(addon.Modifiers);
            energyCost += addon.EnergyCost;
        }

        effects = ApplyPrefireModifiers(effects);
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
                return Add;
            case Enums.Operators.subtract:
                return Subtract;
            case Enums.Operators.multiply:
                return Multiply;
            case Enums.Operators.divide:
                return Divide;
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
        output += "\n-----------\nMODIFIERS\n-----------";
        foreach (WeaponModifier wm in effects)
        {
            output += "\n" + wm.ModType + " " + wm.ModOperator + " " + wm.ModStrength;
        }
        
        return output;
    }

    //basic math for delegate
    private float Add(float fOne, float fTwo) { return fOne + fTwo; }
    private float Subtract(float fOne, float fTwo) { return fOne - fTwo; }
    private float Multiply(float fOne, float fTwo) { return fOne * fTwo; }
    private float Divide(float fOne, float fTwo) { return fOne / fTwo; }
}
