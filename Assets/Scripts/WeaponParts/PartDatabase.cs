using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PartDatabase
{
    [SerializeField] private List<WeaponFrame> _weaponFrames;
    [SerializeField] private List<WeaponBattery> _weaponBatteries;
    [SerializeField] private List<WeaponMagazine> _weaponMagazines;
    [SerializeField] private List<WeaponMuzzle> _weaponMuzzles;
    [SerializeField] private List<WeaponAddon> _weaponAddons;

    public List<WeaponFrame> WeaponFrames { get => _weaponFrames; set => _weaponFrames = value; }
    public List<WeaponBattery> WeaponBatteries { get => _weaponBatteries; set => _weaponBatteries = value; }
    public List<WeaponMagazine> WeaponMagazines { get => _weaponMagazines; set => _weaponMagazines = value; }
    public List<WeaponMuzzle> WeaponMuzzles { get => _weaponMuzzles; set => _weaponMuzzles = value; }
    public List<WeaponAddon> WeaponAddons { get => _weaponAddons; set => _weaponAddons = value; }

    public WeaponPart GetPartByID(string ID)
    {
        //i'm so sorry
        switch(ID[0])
        {
            case '0':
                return GetPartByID<WeaponFrame>(ID, _weaponFrames);
            case '1':
                return GetPartByID<WeaponBattery>(ID, _weaponBatteries);
            case '2':
                return GetPartByID<WeaponMagazine>(ID, _weaponMagazines);
            case '3':
                return GetPartByID<WeaponMuzzle>(ID, _weaponMuzzles);
            case '4':
                return GetPartByID<WeaponAddon>(ID, _weaponAddons);
            default:
                return null;
        }
    }

    public WeaponPart GetPartByID<T>(string ID, List<T> l)
    {
        foreach(T p in l)
        {
            if(p is WeaponPart)
            {
                WeaponPart temp = p as WeaponPart;
                if (temp.Id == ID)
                    return temp;
            }
        }
        Debug.LogError("Unable to find weaponPart of id " + ID + "!");
        return null;
    }
}
