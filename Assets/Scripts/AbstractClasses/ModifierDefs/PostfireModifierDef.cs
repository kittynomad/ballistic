using UnityEngine;

public abstract class PostfireModifierDef : ModifierDef
{
    public abstract void ApplyModifier(float strength, ShootableEntity effectedEntity);
}
