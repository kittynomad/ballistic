using UnityEngine;

[System.Serializable]
public class WeaponConfigIDContainer
{
    [SerializeField] private string _frameID;
    [SerializeField] private string _batteryID;
    [SerializeField] private string _magazineID;
    [SerializeField] private string _muzzleID;
    [SerializeField] private string[] _addonIDs;
}
