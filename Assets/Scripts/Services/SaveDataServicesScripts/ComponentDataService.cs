/*****************************************************************************
// File Name : ComponentDataService.cs
// Author : Pierce Nunnelley
// Creation Date : February 15, 2026
//
// Brief Description : This service distributes data/stats about weapon
// components.
*****************************************************************************/
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using NaughtyAttributes;

public class ComponentDataService : Service
{
    public static ComponentDataService Instance;

    [SerializeField] private PartDatabase _parts;

    public PartDatabase Parts { get => _parts; set => _parts = value; }

    public override async Awaitable Initialize()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        await base.Initialize();
    }

    public WeaponPart GetPartByID(string ID)
    {
        return _parts.GetPartByID(ID);
    }

    public WeaponConfig DefaultWeaponConfig()
    {
        WeaponConfig currentConfig = new WeaponConfig();
        currentConfig.Frame = ComponentDataService.Instance.Parts.GetPartByID("00000") as WeaponFrame;
        currentConfig.Battery = ComponentDataService.Instance.Parts.GetPartByID("10000") as WeaponBattery;
        currentConfig.Magazine = ComponentDataService.Instance.Parts.GetPartByID("20000") as WeaponMagazine;
        currentConfig.Muzzle = ComponentDataService.Instance.Parts.GetPartByID("30000") as WeaponMuzzle;
        currentConfig.Addons = new WeaponAddon[] { ComponentDataService.Instance.Parts.GetPartByID("40000") as WeaponAddon };
        return currentConfig;
    }

    #region savingFunctions
    public void SavePartDatabase(string path)
    {
        string s = JsonUtility.ToJson(_parts, true);
        try
        {
            GUIUtility.systemCopyBuffer = path + "/ComponentDatabase.json";
            Debug.Log(path + "/ComponentDatabase.json");
            
        }
        catch
        {
            Debug.LogWarning("Unable to display save directory");
        }


        File.WriteAllText(path + "/ComponentDatabase.json", s);

    }

    public void LoadPartDatabase(string path)
    {
        string r = File.ReadAllText(path + "/ComponentDatabase.json");
        _parts = JsonUtility.FromJson<PartDatabase>(r);
    }

    [Button]
    public void SavePartDatabaseInternally() { SavePartDatabase(Application.streamingAssetsPath); }
    [Button]
    public void SavePartDatabaseExternally() { SavePartDatabase(Application.persistentDataPath); }
    [Button]
    public void LoadPartDatabaseInternally() { LoadPartDatabase(Application.streamingAssetsPath); }
    [Button]
    public void LoadPartDatabaseExternally() { LoadPartDatabase(Application.persistentDataPath); }

    #endregion
}
