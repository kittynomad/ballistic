using UnityEngine;

public class ParalysisModifier : PostfireModifierDef
{
    public override void ApplyModifier(float strength, Enums.Operators op, ShootableEntity effectedEntity)
    {
        IStatusEffect paralysisEffect = new ParalysisStatusEffect();
        paralysisEffect.OnStartStatus(effectedEntity, strength);
        effectedEntity.CurrentStatuses.Add(paralysisEffect);
    }
}
