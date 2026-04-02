using UnityEngine;

public class MultishotModifier : PrefireStatModifier
{
    private string modDisplayName = "Multishot";
    public override string DisplayName { get => modDisplayName;}
    public override void ApplyModifier(float strength, Enums.Operators op, ref WeaponStats stats)
    {
        ModifyWeaponStat(strength, op, Enums.ModifyableWeaponStats.multishot, ref stats);
    }
}
