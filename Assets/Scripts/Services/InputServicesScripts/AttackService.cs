/*****************************************************************************
// File Name : AttackService.cs
// Author : Pierce Nunnelley
// Creation Date : February 15, 2026
//
// Brief Description : This service handles the player's attacking input.
*****************************************************************************/
using UnityEngine;

public class AttackService : Service
{
    private GameObject bulletPrefab;
    private PlayerBehaviors pb;
    public override async Awaitable Initialize()
    {
        bulletPrefab = Resources.Load("Prefabs/Bullet") as GameObject;
        pb = FindAnyObjectByType<PlayerBehaviors>();
        await base.Initialize();
    }
    public void OnAttack(bool started)
    {
        Debug.Log("attack");
        //get weapon indirectly since it may be reinstantiated
        if(started && pb.gameObject.TryGetComponent(out Weapon w))
        {
            w.FireWeapon();
        }
    }
}
