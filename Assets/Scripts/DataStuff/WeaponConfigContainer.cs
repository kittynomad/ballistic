using UnityEngine;

[System.Serializable]
public class WeaponConfigContainer
{
    [SerializeField] private WeaponConfigIDContainer[] _weaponConfigs;

    public WeaponConfigIDContainer[] WeaponConfigs { get => _weaponConfigs; set => _weaponConfigs = value; }
}
