using System;
using System.Collections.Generic;
using UnityEngine;

public class Dictionaries
{
    public static Dictionary<Enums.Modifiers, Func<IStatusEffect>> ModLookup = new Dictionary<Enums.Modifiers, Func<IStatusEffect>>()
    {
        {Enums.Modifiers.fire, ()=> new DamageOverTimeStatusEffect() },
        {Enums.Modifiers.paralysis, ()=> new ParalysisStatusEffect() },
    };
}
