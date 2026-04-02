using UnityEngine;

public abstract class PrefireStatModifier : PrefireModifierDef
{
    delegate float modifierDelegate(float modifiedVar, float modValue);

    public virtual float ModifyWeaponStat(float strength, Enums.Operators op, Enums.ModifyableWeaponStats statNum, ref WeaponStats stats)
    {
        modifierDelegate m = OperationFromEnum(op);
        switch (statNum)
        {
            case Enums.ModifyableWeaponStats.multishot:
                stats.Multishot = m(stats.Multishot, strength);
                return m(stats.Multishot, strength);
            case Enums.ModifyableWeaponStats.spread:
                stats.Spread = m(stats.Spread, strength);
                return m(stats.Spread, strength);
            case Enums.ModifyableWeaponStats.damage:
                stats.BaseDamage = m(stats.BaseDamage, strength);
                return m(stats.BaseDamage, strength);
            case Enums.ModifyableWeaponStats.velocity:
                stats.StartVelocity = m(stats.StartVelocity, strength);
                return m(stats.StartVelocity, strength);
            case Enums.ModifyableWeaponStats.cooldown:
                stats.TimeBetweenShots = m(stats.TimeBetweenShots, strength);
                return m(stats.TimeBetweenShots, strength);
            case Enums.ModifyableWeaponStats.criticalChance:
                stats.CriticalHitChance = m(stats.CriticalHitChance, strength);
                return m(stats.CriticalHitChance, strength);
            default:
                return -1f;
        }
        
    }

    private modifierDelegate OperationFromEnum(Enums.Operators op)
    {
        switch (op)
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

}
