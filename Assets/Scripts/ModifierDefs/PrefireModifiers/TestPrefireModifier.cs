using UnityEngine;
public class TestPrefireModifier : PrefireModifierDef
{
    public override void ApplyModifier(float strength, WeaponStats stats)
    {
        Debug.Log("I'm here!!");
    }
}
