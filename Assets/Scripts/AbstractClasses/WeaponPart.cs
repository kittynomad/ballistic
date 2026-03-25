/*****************************************************************************
// File Name : WeaponPart.cs
// Author : Pierce Nunnelley
// Creation Date : February 17, 2026
//
// Brief Description : This abstract class acts as the base form for all
// components used in custom weapons, defining variables all parts require.
*****************************************************************************/
using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;

[System.Serializable]
public abstract class WeaponPart
{
    public string _itemName;
    public string _id;
    [SerializeField] private string _itemDescription;
    [SerializeField] private string _itemIconPath;
    [SerializeField] private int _energyCost;

    [SerializeField] private List<WeaponModifier> _modifiers;
    [SerializeField] private string _itemModelPath;

    public string ItemName { get => _itemName; set => _itemName = value; }
    public string ItemDescription { get => _itemDescription; set => _itemDescription = value; }
    public string ItemIconPath { get => _itemIconPath; set => _itemIconPath = value; }
    public string Id { get => _id; set => _id = value; }
    public List<WeaponModifier> Modifiers { get => _modifiers; set => _modifiers = value; }

    public int EnergyCost { get => _energyCost; set => _energyCost = value; }
    public string ItemModelPath { get => _itemModelPath; set => _itemModelPath = value; }

    public GameObject GetPartModel()
    {
        return Resources.Load(_itemModelPath) as GameObject;
    }
}
