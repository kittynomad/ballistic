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
        output.BatteryID = wc.Battery.Id;
        output.MagazineID = wc.Magazine.Id;
        output.MuzzleID = wc.Muzzle.Id;
        output.AddonIDs = new string[wc.Addons.Length];

        for(int i = 0; i < wc.Addons.Length; i++)
        {
            output.AddonIDs[i] = wc.Addons[i].Id;
        }

        return output;
    }
}
