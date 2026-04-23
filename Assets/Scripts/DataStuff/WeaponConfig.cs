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
using NaughtyAttributes;

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
    public WeaponConfig(WeaponFrame f, WeaponBattery b, WeaponMagazine mag, WeaponMuzzle muzzle)
    {
        _frame = f;
        _battery = b;
        _magazine = mag;
        _muzzle = muzzle;
        _addons = new WeaponAddon[_frame.AddonCapacity];
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
        if(part.GetType().Name != "WeaponFrame" && !IsPartCompatible(part))
        {
            Debug.LogWarning("Part isn't compatible! Aborting.");
            return;
        }
        switch (part.GetType().Name)
        {
            case "WeaponFrame":
                _frame = part as WeaponFrame;
                _addons = new WeaponAddon[_frame.AddonCapacity];
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
                EquipAddon(part as WeaponAddon);
                return;

        }
    }

    public void RemovePart(System.Type partType)
    {
        switch (partType.Name)
        {
            case "WeaponFrame":
                Debug.LogError("Cannot remove frame. Use ReplacePart for different frame");
                return;
            case "WeaponBattery":
                _battery = null;
                return;
            case "WeaponMagazine":
                _magazine = null;
                return;
            case "WeaponMuzzle":
                _muzzle = null;
                return;
            case "WeaponAddon":
                Debug.LogError("Cannot remove addon with RemovePart! Use RemoveAddon instead.");
                return;

        }
    }

    private bool IsPartCompatible(WeaponPart part)
    {
        foreach(PartTagContainer i in part.PartTags)
        {
            PartCategoryTag partTag = i.PartCategory;

            foreach(PartTagContainer j in _frame.PartTags)
            {
                PartCategoryTag frameTag = j.PartCategory;

                if(partTag.GetType().Name == frameTag.GetType().Name)
                {
                    return true;
                }
            }

        }

        return false;
    }

    private bool EquipAddon(WeaponAddon addon)
    {
        if(_addons == null)
        {
            _addons = new WeaponAddon[_frame.AddonCapacity];
        }

        for(int i = 0; i < _addons.Length; i++)
        {
            if(_addons[i] == null)
            {
                _addons[i] = addon;
                return true;
            }
        }
        Debug.LogWarning("Could not equip addon-- not enough room");
        return false;
    }

    public void RemoveAddon(int index)
    {
        _addons = HelperFunctions.GroupNonNullArrayEntries<WeaponAddon>(HelperFunctions.RemoveElementFromArray<WeaponAddon>(_addons, index), _addons.Length);
    }

    public override string ToString()
    {
        string output = "CONFIG\n----------";
        output += "\nFrame: " + _frame.ItemName;
        output += "\nBattery: " + (_battery == null ? "!!NONE!!" : _battery.ItemName);
        output += "\nMagazine: " + (_magazine == null ? "!!NONE!!" : _magazine.ItemName);
        output += "\nMuzzle: " + (_muzzle == null ? "!!NONE!!" : _muzzle.ItemName);
        foreach(WeaponAddon addon in _addons)
        {
            if(addon != null)
            output += "\nAddon: " + addon.ItemName;
        }
        return output;
    }
}
