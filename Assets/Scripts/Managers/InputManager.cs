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
    [SerializeField] private GameObject _eventSystem;
    private MovementService ms;
    private AimService aims;
    private AttackService att;
    public override async Awaitable Initialize()
    {
        Instantiate(_eventSystem);
        await base.Initialize();
        ms = FindAnyObjectByType<MovementService>();
        aims = FindAnyObjectByType<AimService>();
        att = FindAnyObjectByType<AttackService>();
        await Awaitable.EndOfFrameAsync();
    }

    public void OnMove(InputValue iVal)
    {
        ms.MovementVector = iVal.Get<Vector2>();
    }

    public void OnLook(InputValue iVal)
    {
        aims.LookVector = iVal.Get<Vector2>();
    }

    public void OnAttack(InputValue iVal)
    {
        Debug.Log(iVal.Get<float>());
        att.OnAttack(iVal.Get<float>() > 0);
    }

    public void OnMenu()
    {
        FindAnyObjectByType<AssemblyUIService>().OpenAssemblyUI();
    }
}
