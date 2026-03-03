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
}
