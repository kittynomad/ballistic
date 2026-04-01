using UnityEngine;

public class DamageModifier : PrefireStatModifier
{
    public override void ApplyModifier(float strength, Enums.Operators op, ref WeaponStats stats)
    {
        ModifyWeaponStat(strength, op, Enums.ModifyableWeaponStats.damage, ref stats);
    }
}
