using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponConfigContainer
{
    [SerializeField] private List<WeaponConfigIDContainer> _weaponConfigs;

    public List<WeaponConfigIDContainer> WeaponConfigs { get => _weaponConfigs; set => _weaponConfigs = value; }
}
