using System;
using System.Collections.Generic;
using UnityEngine;

public class ParalysisModifier : PostfireModifierDef
{
    public override void ApplyModifier(float strength, Enums.Operators op, ShootableEntity effectedEntity)
    {
        if(CheckIfEffectAlreadyApplied(typeof(ParalysisStatusEffect), effectedEntity.CurrentStatuses, out int index))
        {
            StackableStatusEffect t = (StackableStatusEffect)effectedEntity.CurrentStatuses[index];
            t.OnNewStack(strength);
        }
        else
        {
            IStatusEffect paralysisEffect = new ParalysisStatusEffect();
            paralysisEffect.OnStartStatus(effectedEntity, strength);
            effectedEntity.CurrentStatuses.Add(paralysisEffect);
        }
        
    }

    public bool CheckIfEffectAlreadyApplied(Type effectType, List<IStatusEffect> effects, out int index)
    {
        for(int i = 0; i < effects.Count; i++)
        {
            if(effects[i].GetType().Equals(effectType))
            {
                index = i;
                return true;
            }
        }
        index = -1;
        return false;
    }
}
