using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PartDatabase
{
    [SerializeField] private List<WeaponFrame> _weaponFrames;
    [SerializeField] private List<WeaponBattery> _weaponBatteries;
    [SerializeField] private List<WeaponMagazine> _weaponMagazines;

    public List<WeaponFrame> WeaponFrames { get => _weaponFrames; set => _weaponFrames = value; }
    public List<WeaponBattery> WeaponBatteries { get => _weaponBatteries; set => _weaponBatteries = value; }
    public List<WeaponMagazine> WeaponMagazines { get => _weaponMagazines; set => _weaponMagazines = value; }
}
