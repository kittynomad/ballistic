using UnityEngine;

public class WeaponBattery : WeaponPart
{
    [SerializeField] private float _capacity;
    [SerializeField] private float _rechargeRate;

    public float Capacity { get => _capacity; set => _capacity = value; }
    public float RechargeRate { get => _rechargeRate; set => _rechargeRate = value; }
}
