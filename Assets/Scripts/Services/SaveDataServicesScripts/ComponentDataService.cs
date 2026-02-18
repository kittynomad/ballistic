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
    [SerializeField] private PartDatabase _parts;
    public PartDatabase Parts { get => _parts; set => _parts = value; }

    [Button]
    public void SavePartDatabase()
    {
        string s = JsonUtility.ToJson(_parts, true);

        GUIUtility.systemCopyBuffer = Application.persistentDataPath + "/ComponentDatabase.json";
        Debug.Log(Application.persistentDataPath + "/ComponentDatabase.json");
        File.WriteAllText(Application.persistentDataPath + "/ComponentDatabase.json", s);

    }
}
