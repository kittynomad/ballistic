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
    [Tooltip("The display name used by a part on UI. While this doesn't have to be unique, it probably should be to avoid confusion.")]
    public string _itemName;

    [Tooltip("An integer used to identify a specific part. This should be a unique value.")]
    public string _id;

    [Tooltip("A basic description of the part, used in the assembly screen.")]
    [SerializeField] private string _itemDescription;

    [Tooltip("The image used to display the part in 2D menus. Stored as a string of the directory, using Resources as the root folder.")]
    [SerializeField] private string _itemIconPath;

    [Tooltip("The charge required from the weapon's battery to fire once with this component installed. all individual energy costs of all used parts are added for the total cost of firing an assembled weapon.")]
    [SerializeField] private int _energyCost;

    [Tooltip("An array of all special effects this part has. Effects are defined as scripts inheriting from ModifierDef.")]
    [SerializeField] private List<WeaponModifier> _modifiers;

    [Tooltip("The 3D model representing this part, used on the assembled weapon's combined model. Stored as a string of the directory, using Resources as the root folder.")]
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
