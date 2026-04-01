using UnityEngine;
public class TestPrefireModifier : PrefireModifierDef
{
    public override void ApplyModifier(float strength, Enums.Operators op, ref WeaponStats stats)
    {
        Debug.Log("I'm here!!");
    }
}
