/*****************************************************************************
// File Name : HudService.cs
// Author : Pierce Nunnelley
// Creation Date : February 15, 2026
//
// Brief Description : This service handles behavior related to the primary
// gameplay hud.
*****************************************************************************/
using UnityEngine;
using UnityEngine.UI;

public class HudService : Service
{
    public static HudService Instance;
    private GameObject hudUI;
    private MainHUDReferences hudRefs;
    private ConsoleMessagesController cmc;

    public override async Awaitable Initialize()
    {
        Instance = this;
        GameObject temp = Resources.Load("UI/MainHUD") as GameObject;
        hudUI = Instantiate(temp);
        await FindAnyObjectByType<ConsoleMessagesController>().Initialize();
        cmc = FindAnyObjectByType<ConsoleMessagesController>();
        hudRefs = FindAnyObjectByType<MainHUDReferences>();
        //await hudUI.GetComponent<PartListDisplayController>().Initialize();
        await base.Initialize();
    }

    public void PushConsoleMessage(string message)
    {
        cmc.PushMessage(message);
    }

    public void UpdateBatteryMeter(float curBattery, float maxBattery)
    {
        hudRefs.BatteryMeter.value = curBattery / maxBattery;
    }
}
