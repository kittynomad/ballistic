using UnityEngine;

public class CooldownModifier : PrefireStatModifier
{
    public override void ApplyModifier(float strength, Enums.Operators op, ref WeaponStats stats)
    {
        ModifyWeaponStat(strength, op, Enums.ModifyableWeaponStats.cooldown, ref stats);
    }
}
