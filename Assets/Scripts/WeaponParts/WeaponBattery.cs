using UnityEngine;

[System.Serializable]
public class WeaponBattery : WeaponPart
{
    [Tooltip("The maximum charge that this battery can hold. This affects how much can be fired before waiting for recharge.")]
    [SerializeField] private float _capacity;

    [Tooltip("The rate at which the charge of the battery refills while not firing.")]
    [SerializeField] private float _rechargeRate;

    public float Capacity { get => _capacity; set => _capacity = value; }
    public float RechargeRate { get => _rechargeRate; set => _rechargeRate = value; }
}
