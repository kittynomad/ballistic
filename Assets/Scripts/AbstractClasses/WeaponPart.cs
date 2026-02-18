using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;

[System.Serializable]
public abstract class WeaponPart
{
    public string _id;
    public string _itemName;
    [SerializeField] private string _itemDescription;
    [SerializeField] private string _itemIconPath;

    [SerializeField] private List<WeaponModifier> _modifiers;

    public string ItemName { get => _itemName; set => _itemName = value; }
    public string ItemDescription { get => _itemDescription; set => _itemDescription = value; }
    public string ItemIconPath { get => _itemIconPath; set => _itemIconPath = value; }
    public string Id { get => _id; set => _id = value; }
    public List<WeaponModifier> Modifiers { get => _modifiers; set => _modifiers = value; }
}
