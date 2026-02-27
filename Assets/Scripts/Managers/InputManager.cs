/*****************************************************************************
// File Name : InputManager.cs
// Author : Pierce Nunnelley
// Creation Date : February 13, 2026
//
// Brief Description : This script initializes services for input-related
// behavior.
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Manager
{
    private MovementService ms;
    private AimService aims;
    public override async Awaitable Initialize()
    {
        await base.Initialize();
        ms = FindAnyObjectByType<MovementService>();
        aims = FindAnyObjectByType<AimService>();
    }

    public void OnMove(InputValue iVal)
    {
        ms.MovementVector = iVal.Get<Vector2>();
    }

    public void OnLook(InputValue iVal)
    {
        aims.LookVector = iVal.Get<Vector2>();
    }
}
