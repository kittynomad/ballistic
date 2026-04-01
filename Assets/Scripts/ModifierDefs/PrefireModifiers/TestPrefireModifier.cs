using UnityEngine;
public class TestPrefireModifier : PrefireModifierDef
{
    public override void ApplyModifier(float strength, Enums.Operators op, WeaponStats stats)
    {
        Debug.Log("I'm here!!");
    }
}
