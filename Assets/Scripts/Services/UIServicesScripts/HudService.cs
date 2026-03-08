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
    public static HudService Instance;
    private GameObject hudUI;
    private ConsoleMessagesController cmc;

    public override async Awaitable Initialize()
    {
        Instance = this;
        GameObject temp = Resources.Load("UI/MainHUD") as GameObject;
        hudUI = Instantiate(temp);
        await FindAnyObjectByType<ConsoleMessagesController>().Initialize();
        cmc = FindAnyObjectByType<ConsoleMessagesController>();
        //await hudUI.GetComponent<PartListDisplayController>().Initialize();
        await base.Initialize();
    }

    public void PushConsoleMessage(string message)
    {
        cmc.PushMessage(message);
    }
}
