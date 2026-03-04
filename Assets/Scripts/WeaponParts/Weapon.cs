using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponConfig _config;
    private WeaponStats stats;

    public WeaponConfig Config { get => _config; set => _config = value; }
    public WeaponStats Stats { get => stats; set => stats = value; }
}
