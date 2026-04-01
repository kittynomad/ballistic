using UnityEngine;

public abstract class PrefireStatModifier : PrefireModifierDef
{
    delegate float modifierDelegate(float modifiedVar, float modValue);

    public override void ApplyModifier(float strength, Enums.Operators op, WeaponStats stats)
    {
        throw new System.NotImplementedException();
    }

    public virtual void ModifyWeaponStat(float strength, Enums.Operators op, Enums.ModifyableWeaponStats statNum, WeaponStats stats)
    {
        modifierDelegate m = OperationFromEnum(op);
        switch (statNum)
        {
            case Enums.ModifyableWeaponStats.multishot:
                stats.Multishot = m(stats.Multishot, strength);
                return;
            case Enums.ModifyableWeaponStats.spread:
                stats.Spread = m(stats.Spread, strength);
                return;
            case Enums.ModifyableWeaponStats.damage:
                stats.BaseDamage = m(stats.BaseDamage, strength);
                return;
            case Enums.ModifyableWeaponStats.velocity:
                stats.StartVelocity = m(stats.StartVelocity, strength);
                return;
            case Enums.ModifyableWeaponStats.cooldown:
                stats.TimeBetweenShots = m(stats.TimeBetweenShots, strength);
                return;
            case Enums.ModifyableWeaponStats.criticalChance:
                stats.CriticalHitChance = m(stats.CriticalHitChance, strength);
                return;
            default:
                return;
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
