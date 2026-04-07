using UnityEngine;

public class HealingModifier : PostfireModifierDef
{
    private string modDisplayName = "Healing";
    public override string DisplayName { get => modDisplayName; }
    public override void ApplyModifier(float strength, Enums.Operators op, ShootableEntity effectedEntity)
    {
        IStatusEffect healEffect = new HealOverTimeStatusEffect();
        healEffect.OnStartStatus(effectedEntity, strength);
        effectedEntity.CurrentStatuses.Add(healEffect);
    }

}
