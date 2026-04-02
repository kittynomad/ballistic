using UnityEngine;

public class SpreadModifier : PrefireStatModifier
{
    public override void ApplyModifier(float strength, Enums.Operators op, ref WeaponStats stats)
    {
        ModifyWeaponStat(strength, op, Enums.ModifyableWeaponStats.spread, ref stats);
    }
}
