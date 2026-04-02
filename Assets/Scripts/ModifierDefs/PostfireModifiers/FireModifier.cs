using UnityEngine;

public class FireModifier : PostfireModifierDef
{
    private string modDisplayName = "Burning";
    public override string DisplayName { get => modDisplayName;}
    public override void ApplyModifier(float strength, Enums.Operators op, ShootableEntity effectedEntity)
    {
        IStatusEffect fireEffect = new DamageOverTimeStatusEffect();
        fireEffect.OnStartStatus(effectedEntity, strength);
        effectedEntity.CurrentStatuses.Add(fireEffect);
    }

}
