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
    private FrameModelController viewModel;

    public static Vector3 VIEWMODEL_POSITION = new Vector3(-200, -200, -200);

    public GameObject AssemblyUI { get => assemblyUI; set => assemblyUI = value; }

    public override async Awaitable Initialize()
    {
        await InitiateConfig();
        GameObject temp = Resources.Load("UI/AssemblyScreen") as GameObject;
        AssemblyUI = Instantiate(temp);
        await AssemblyUI.GetComponent<PartListDisplayController>().Initialize();
        //assemblyUI.SetActive(false);
        OpenAssemblyUI();
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
        if (viewModel != null) viewModel.DestroyModel();

        FrameModelController f = Instantiate(currentConfig.Frame.GetPartModel(), VIEWMODEL_POSITION, currentConfig.Frame.GetPartModel().transform.rotation).GetComponent<FrameModelController>();
        f.ConnectPart(currentConfig.Battery.GetPartModel(), f.BatteryConnectionPoint);
        f.ConnectPart(currentConfig.Magazine.GetPartModel(), f.MagazineConnectionPoint);
        f.ConnectPart(currentConfig.Muzzle.GetPartModel(), f.MuzzleConnectionPoint);
        f.ConnectModifierParts(currentConfig.Addons);
        viewModel = f;

        AssemblyUI.GetComponent<PartListDisplayController>().Description.text = currentConfig.ToString();

    }

    public void OpenAssemblyUI()
    {
        assemblyUI.SetActive(true);
        FindAnyObjectByType<CameraManager>().SetAssemblyModeCamera();
    }

    public void UpdateConfigData(WeaponPart part)
    {
        currentConfig.ReplacePart(part);
        Debug.Log(currentConfig);
        UpdateWeaponViewModel();
    }

    public void RandomizeConfig()
    {
        UpdateConfigData(ComponentDataService.Instance.Parts.WeaponFrames[(int)Random.Range(0, ComponentDataService.Instance.Parts.WeaponFrames.Count)]);
        UpdateConfigData(ComponentDataService.Instance.Parts.WeaponBatteries[(int)Random.Range(0, ComponentDataService.Instance.Parts.WeaponBatteries.Count)]);
        UpdateConfigData(ComponentDataService.Instance.Parts.WeaponMagazines[(int)Random.Range(0, ComponentDataService.Instance.Parts.WeaponMagazines.Count)]);
        UpdateConfigData(ComponentDataService.Instance.Parts.WeaponMuzzles[(int)Random.Range(0, ComponentDataService.Instance.Parts.WeaponMuzzles.Count)]);
        
        for(int i = 0; i < currentConfig.Frame.AddonCapacity; i++)
        {
            UpdateConfigData(ComponentDataService.Instance.Parts.WeaponAddons[(int)Random.Range(0, ComponentDataService.Instance.Parts.WeaponAddons.Count)]);
        }
    }

    public void SetCurrentConfig(WeaponConfig w)
    {
        currentConfig = w;
        UpdateWeaponViewModel();
    }

    public void ConfirmLoadout()
    {
        FindAnyObjectByType<WeaponAssemblyService>().AssembleWeapon(currentConfig);
        FindAnyObjectByType<CameraManager>().SetGameplayModeCamera();
        HudService.Instance.PushConsoleMessage("Weapon assembled! Press M to edit");
    }
}
