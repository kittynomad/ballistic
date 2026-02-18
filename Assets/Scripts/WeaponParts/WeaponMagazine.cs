using UnityEngine;

[System.Serializable]
public class WeaponMagazine : WeaponPart
{
    [SerializeField] private int _magSize;
    [SerializeField] private float _reloadTime;
    [SerializeField] private bool _automaticFire = false;

    public int MagSize { get => _magSize; set => _magSize = value; }
    public float ReloadTime { get => _reloadTime; set => _reloadTime = value; }
    public bool AutomaticFire { get => _automaticFire; set => _automaticFire = value; }
}
