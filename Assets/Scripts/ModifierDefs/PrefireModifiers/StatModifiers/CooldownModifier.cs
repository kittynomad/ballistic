using UnityEngine;

public class CooldownModifier : PrefireStatModifier
{
    private string modDisplayName = "Cooldown";
    public override string DisplayName { get => modDisplayName;}
    public override void ApplyModifier(float strength, Enums.Operators op, ref WeaponStats stats)
    {
        ModifyWeaponStat(strength, op, Enums.ModifyableWeaponStats.cooldown, ref stats);
    }
}
