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
    public override async Awaitable Initialize()
    {
        bulletPrefab = Resources.Load("Prefabs/Bullet") as GameObject;
        await base.Initialize();
    }
    public void OnAttack()
    {
        Debug.Log("attack");
        Instantiate(bulletPrefab, Camera.main.transform.position, Quaternion.identity);
    }
}
