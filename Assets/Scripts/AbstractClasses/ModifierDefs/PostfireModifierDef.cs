using UnityEngine;

public abstract class PostfireModifierDef : ModifierDef
{
    public abstract void ApplyModifier(float strength, Enums.Operators op, ShootableEntity effectedEntity);
}
