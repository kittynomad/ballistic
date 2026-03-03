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
}
