using UnityEngine;

public abstract class PrefireModifierDef : ModifierDef
{
    public abstract void ApplyModifier(float strength, Enums.Operators op, ref WeaponStats stats);
}
