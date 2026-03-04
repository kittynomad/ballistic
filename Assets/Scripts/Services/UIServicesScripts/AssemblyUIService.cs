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
        //assemblyUI.SetActive(false);
        UpdateWeaponViewModel();
        await base.Initialize();
    }

    //give currentConfig values to avoid nulling out
    private async Awaitable InitiateConfig()
    {
        if(false)
        {
            //check if player already has weapon and initiate with that if they do
        }
        else
        {
            currentConfig = ComponentDataService.Instance.DefaultWeaponConfig();
        }
        await Awaitable.NextFrameAsync();
    }

    //create model of weapon and add correct part models
    public void UpdateWeaponViewModel()
    {
        FrameModelController f = Instantiate(currentConfig.Frame.GetPartModel()).GetComponent<FrameModelController>();
        f.ConnectPart(currentConfig.Battery.GetPartModel(), f.BatteryConnectionPoint);
        f.ConnectPart(currentConfig.Magazine.GetPartModel(), f.MagazineConnectionPoint);
        f.ConnectPart(currentConfig.Muzzle.GetPartModel(), f.MuzzleConnectionPoint);

    }

    public void UpdateConfigData(WeaponPart part)
    {
        currentConfig.ReplacePart(part);
        Debug.Log(currentConfig);
    }

    public void SetCurrentConfig(WeaponConfig w)
    {
        currentConfig = w;
    }
}
