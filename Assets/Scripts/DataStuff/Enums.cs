using UnityEngine;

public class Enums
{
    //manually setting enum vals so json doesn't mess up when reordering
    public enum Modifiers
    {
        fire = 0,
        electricity = 1,
        multishot = 2,
        spread = 3,
        healing = 4,
        damage = 5,
        velocity = 6,
    }

    public enum Operators
    {
        add,
        subtract,
        multiply,
        divide
    }
}
