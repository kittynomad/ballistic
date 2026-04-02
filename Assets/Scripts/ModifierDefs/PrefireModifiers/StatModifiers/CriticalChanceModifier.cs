using UnityEngine;

public class CriticalChanceModifier : PrefireStatModifier
{
    private string modDisplayName = "Crit Chance";
    public override string DisplayName { get => modDisplayName;}

    public override void ApplyModifier(float strength, Enums.Operators op, ref WeaponStats stats)
    {
        ModifyWeaponStat(strength, op, Enums.ModifyableWeaponStats.criticalChance, ref stats);
    }
}
