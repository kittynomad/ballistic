using UnityEngine;

[System.Serializable]
public abstract class WeaponPart
{
    [SerializeField] private string _itemName;
    [SerializeField] private string _itemDescription;
    [SerializeField] private string _itemIconPath;

    public string ItemName { get => _itemName; set => _itemName = value; }
    public string ItemDescription { get => _itemDescription; set => _itemDescription = value; }
    public string ItemIconPath { get => _itemIconPath; set => _itemIconPath = value; }
}
