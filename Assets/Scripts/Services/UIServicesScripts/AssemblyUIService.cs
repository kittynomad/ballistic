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
        GameObject temp = Resources.Load("UI/AssemblyScreen") as GameObject;
        assemblyUI = Instantiate(temp);
        await assemblyUI.GetComponent<PartListDisplayController>().Initialize();
        assemblyUI.SetActive(false);
        await base.Initialize();
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
