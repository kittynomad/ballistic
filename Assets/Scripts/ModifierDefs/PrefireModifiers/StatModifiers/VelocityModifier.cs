using UnityEngine;

public class VelocityModifier : PrefireStatModifier
{
    public override void ApplyModifier(float strength, Enums.Operators op, ref WeaponStats stats)
    {
        ModifyWeaponStat(strength, op, Enums.ModifyableWeaponStats.velocity, ref stats);
    }
}
