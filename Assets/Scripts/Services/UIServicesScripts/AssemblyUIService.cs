/*****************************************************************************
// File Name : AssemblyUIService.cs
// Author : Pierce Nunnelley
// Creation Date : February 15, 2026
//
// Brief Description : This service handles behavior tied to the weapon
// assembly interface.
*****************************************************************************/
using UnityEngine;

public class AssemblyUIService : Service
{
    private GameObject assemblyUI;
    private WeaponConfig currentConfig;
    public override async Awaitable Initialize()
    {
        await InitiateConfig();
        GameObject temp = Resources.Load("UI/AssemblyScreen") as GameObject;
        assemblyUI = Instantiate(temp);
        await assemblyUI.GetComponent<PartListDisplayController>().Initialize();
        assemblyUI.SetActive(false);
        await base.Initialize();
    }

    private async Awaitable InitiateConfig()
    {
        if(false)
        {
            //check if player already has weapon and initiate with that if they do
        }
        else
        {
            currentConfig = new WeaponConfig();
            currentConfig.Frame = ComponentDataService.Instance.Parts.GetPartByID("00000") as WeaponFrame;
            currentConfig.Battery = ComponentDataService.Instance.Parts.GetPartByID("10000") as WeaponBattery;
            currentConfig.Magazine = ComponentDataService.Instance.Parts.GetPartByID("20000") as WeaponMagazine;
            currentConfig.Muzzle = ComponentDataService.Instance.Parts.GetPartByID("30000") as WeaponMuzzle;
            currentConfig.Addons = null;
        }
        await Awaitable.NextFrameAsync();
    }

    public void UpdateConfigData(WeaponPart part)
    {
        currentConfig.ReplacePart(part);
    }

    public void SetCurrentConfig(WeaponConfig w)
    {
        currentConfig = w;
    }
}
