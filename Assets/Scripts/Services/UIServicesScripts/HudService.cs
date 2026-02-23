/*****************************************************************************
// File Name : HudService.cs
// Author : Pierce Nunnelley
// Creation Date : February 15, 2026
//
// Brief Description : This service handles behavior related to the primary
// gameplay hud.
*****************************************************************************/
using UnityEngine;

public class HudService : Service
{
    private GameObject hudUI;

    public override async Awaitable Initialize()
    {
        GameObject temp = Resources.Load("UI/MainHUD") as GameObject;
        hudUI = Instantiate(temp);
        //await hudUI.GetComponent<PartListDisplayController>().Initialize();
        await base.Initialize();
    }
}
