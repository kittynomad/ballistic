using UnityEngine;

public class CriticalChanceModifier : PrefireStatModifier
{
    public override void ApplyModifier(float strength, Enums.Operators op, ref WeaponStats stats)
    {
        ModifyWeaponStat(strength, op, Enums.ModifyableWeaponStats.criticalChance, ref stats);
    }
}
