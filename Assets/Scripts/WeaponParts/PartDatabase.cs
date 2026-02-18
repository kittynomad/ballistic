using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PartDatabase
{
    [SerializeField] private List<WeaponPart> _weaponParts;

    public List<WeaponPart> WeaponParts { get => _weaponParts; set => _weaponParts = value; }
}
