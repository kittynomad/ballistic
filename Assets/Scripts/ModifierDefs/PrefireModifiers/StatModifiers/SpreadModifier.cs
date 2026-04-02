using UnityEngine;

public class SpreadModifier : PrefireStatModifier
{
    private string modDisplayName = "Spread";
    public override string DisplayName { get => modDisplayName;}
    public override void ApplyModifier(float strength, Enums.Operators op, ref WeaponStats stats)
    {
        ModifyWeaponStat(strength, op, Enums.ModifyableWeaponStats.spread, ref stats);
    }
}
