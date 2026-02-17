using UnityEngine;

public abstract class WeaponPart : MonoBehaviour
{
    [SerializeField] private string _itemName;
    [SerializeField] private string _itemDescription;
    [SerializeField] private string _itemIconPath;
}
