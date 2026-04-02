using UnityEngine;

public class VelocityModifier : PrefireStatModifier
{
    private string modDisplayName = "Velocity";
    public override string DisplayName { get => modDisplayName;}
    public override void ApplyModifier(float strength, Enums.Operators op, ref WeaponStats stats)
    {
        ModifyWeaponStat(strength, op, Enums.ModifyableWeaponStats.velocity, ref stats);
    }
}
