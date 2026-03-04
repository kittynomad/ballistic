/*****************************************************************************
// File Name : WeaponConfig.cs
// Author : Pierce Nunnelley
// Creation Date : March 3, 2026
//
// Brief Description : WeaponConfig is a simple data type for storing a 
// "complete" weapon, specifically each used component. For combined stats,
// see WeaponStats.
*****************************************************************************/
using UnityEngine;

public struct WeaponConfig
{
    [SerializeField] private WeaponFrame _frame;
    [SerializeField] private WeaponBattery _battery;
    [SerializeField] private WeaponMagazine _magazine;
    [SerializeField] private WeaponMuzzle _muzzle;
    [SerializeField] private WeaponAddon[] _addons;

    public WeaponFrame Frame { get => _frame; set => _frame = value; }
    public WeaponBattery Battery { get => _battery; set => _battery = value; }
    public WeaponMagazine Magazine { get => _magazine; set => _magazine = value; }
    public WeaponMuzzle Muzzle { get => _muzzle; set => _muzzle = value; }
    public WeaponAddon[] Addons { get => _addons; set => _addons = value; }

    public WeaponConfig(WeaponFrame f, WeaponBattery b, WeaponMagazine mag, WeaponMuzzle muzzle, WeaponAddon[] addons)
    {
        _frame = f;
        _battery = b;
        _magazine = mag;
        _muzzle = muzzle;
        _addons = addons;
    }

    /*public WeaponConfig()
    {
        _frame = ComponentDataService.Instance.Parts.GetPartByID("00000") as WeaponFrame;
        _battery = ComponentDataService.Instance.Parts.GetPartByID("10000") as WeaponBattery;
        _magazine = ComponentDataService.Instance.Parts.GetPartByID("20000") as WeaponMagazine;
        _muzzle = ComponentDataService.Instance.Parts.GetPartByID("30000") as WeaponMuzzle;
        _addons = null;

    }*/

    public void ReplacePart(WeaponPart part)
    {
        switch (part.GetType().Name)
        {
            case "WeaponFrame":
                _frame = part as WeaponFrame;
                return;
            case "WeaponBattery":
                _battery = part as WeaponBattery;
                return;
            case "WeaponMagazine":
                _magazine = part as WeaponMagazine;
                return;
            case "WeaponMuzzle":
                _muzzle = part as WeaponMuzzle;
                return;
            case "WeaponAddon":
                Debug.LogError("Replacing addons in WeaponConfig not yet implemented");
                return;

        }
    }

    public override string ToString()
    {
        string output = "CONFIG\n----------";
        output += "\nFrame: " + _frame.ItemName;
        output += "\nBattery: " + _battery.ItemName;
        output += "\nMagazine: " + _magazine.ItemName;
        output += "\nMuzzle: " + _muzzle.ItemName;
        return output;
    }
}
