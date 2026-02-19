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

    [Button]
    public void SavePartDatabaseInternally() { SavePartDatabase(Application.streamingAssetsPath); }
    [Button]
    public void SavePartDatabaseExternally() { SavePartDatabase(Application.persistentDataPath); }
    [Button]
    public void LoadPartDatabaseInternally() { LoadPartDatabase(Application.streamingAssetsPath); }
    [Button]
    public void LoadPartDatabaseExternally() { LoadPartDatabase(Application.persistentDataPath); }

    public void SavePartDatabase(string path)
    {
        string s = JsonUtility.ToJson(_parts, true);

        GUIUtility.systemCopyBuffer = path + "/ComponentDatabase.json";
        Debug.Log(path + "/ComponentDatabase.json");
        File.WriteAllText(path + "/ComponentDatabase.json", s);

    }

    public void LoadPartDatabase(string path)
    {
        string r = File.ReadAllText(path + "/ComponentDatabase.json");
        _parts = JsonUtility.FromJson<PartDatabase>(r);
    }
}
