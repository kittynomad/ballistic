using UnityEngine;

public class DamageModifier : PrefireStatModifier
{
    private string modDisplayName = "Damage";
    public override string DisplayName { get => modDisplayName;}
    public override void ApplyModifier(float strength, Enums.Operators op, ref WeaponStats stats)
    {
        ModifyWeaponStat(strength, op, Enums.ModifyableWeaponStats.damage, ref stats);
    }
}
