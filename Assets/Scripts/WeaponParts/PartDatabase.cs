using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PartDatabase
{
    [SerializeField] private List<WeaponFrame> _weaponFrames;
    [SerializeField] private List<WeaponBattery> _weaponBatteries;
    [SerializeField] private List<WeaponMagazine> _weaponMagazines;

}
