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

    public WeaponStats(string name)
    {
        baseDamage = 0;
        spread = 0f;
        multishot = 0f;
        reloadTime = 0f;
        energyCost = 0;
        magSize = 0;
        startVelocity = 1;
        effects = null;
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
        string output = "\n";
        output += "\ndamage: " + baseDamage;
        output += "\nspread: " + spread;
        output += "\nmultishot: " + multishot;
        output += "\nreloadTime: " + reloadTime;
        output += "\nenergyCost: " + energyCost;
        output += "\nmagSize: " + magSize;
        output += "\nstartVelocity: " + startVelocity;
        effects = null;
        return output;
    }

    //basic math for delegate
    private float Add(float fOne, float fTwo) { return fOne + fTwo; }
    private float Subtract(float fOne, float fTwo) { return fOne - fTwo; }
    private float Multiply(float fOne, float fTwo) { return fOne * fTwo; }
    private float Divide(float fOne, float fTwo) { return fOne / fTwo; }
}
