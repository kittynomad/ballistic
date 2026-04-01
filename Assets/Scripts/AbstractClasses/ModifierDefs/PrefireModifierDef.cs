using UnityEngine;

public abstract class PrefireModifierDef : ModifierDef
{
    public abstract void ApplyModifier(float strength, WeaponStats stats);
}
