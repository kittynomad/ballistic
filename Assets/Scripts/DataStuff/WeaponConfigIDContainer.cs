using UnityEngine;

[System.Serializable]
public class WeaponConfigIDContainer
{
    [SerializeField] private string _frameID;
    [SerializeField] private string _batteryID;
    [SerializeField] private string _magazineID;
    [SerializeField] private string _muzzleID;
    [SerializeField] private string[] _addonIDs;

    public string FrameID { get => _frameID; set => _frameID = value; }
    public string BatteryID { get => _batteryID; set => _batteryID = value; }
    public string MagazineID { get => _magazineID; set => _magazineID = value; }
    public string MuzzleID { get => _muzzleID; set => _muzzleID = value; }
    public string[] AddonIDs { get => _addonIDs; set => _addonIDs = value; }

    public static WeaponConfigIDContainer WeaponToIDContainer(WeaponConfig wc)
    {
        WeaponConfigIDContainer output = new WeaponConfigIDContainer();
        output.FrameID = wc.Frame.Id;
        output.BatteryID = wc.Battery == null ? null : wc.Battery.Id;
        output.MagazineID = wc.Magazine == null ? null : wc.Magazine.Id;
        output.MuzzleID = wc.Muzzle == null ? null : wc.Muzzle.Id;
        output.AddonIDs = new string[wc.Addons.Length];

        for(int i = 0; i < wc.Addons.Length; i++)
        {
            if(wc.Addons[i] != null)
            output.AddonIDs[i] = wc.Addons[i].Id;
        }

        return output;
    }

    public static WeaponConfig IDContainerToWeaponConfig(WeaponConfigIDContainer wcic)
    {
        WeaponAddon[] addons = new WeaponAddon[wcic.AddonIDs.Length];

        for(int i = 0; i < wcic.AddonIDs.Length; i++)
        {
            addons[i] = ComponentDataService.Instance.GetPartByID(wcic.AddonIDs[i]) as WeaponAddon;
        }

        WeaponConfig output = new WeaponConfig(
            ComponentDataService.Instance.GetPartByID(wcic.FrameID) as WeaponFrame,
            ComponentDataService.Instance.GetPartByID(wcic.BatteryID) as WeaponBattery,
            ComponentDataService.Instance.GetPartByID(wcic.MagazineID) as WeaponMagazine,
            ComponentDataService.Instance.GetPartByID(wcic.MuzzleID) as WeaponMuzzle,
            addons);

        return output;
    }
}
