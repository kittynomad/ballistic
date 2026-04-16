using UnityEngine;

[System.Serializable]
public class WeaponFrame : WeaponPart
{
    [Tooltip("The speed at which projectiles exit the weapon. 1 is considered default.")]
    [SerializeField] private float _fireVelocity = 1f;

    [Tooltip("The total amount of addons that can be attached to this frame.")]
    [SerializeField] private int _addonCapacity = 3;

    [Tooltip("The chance of a critical hit, as a percent.")]
    [SerializeField] private float _baseCritChance = 10f;

    public float FireVelocity { get => _fireVelocity; set => _fireVelocity = value; }
    public int AddonCapacity { get => _addonCapacity; set => _addonCapacity = value; }
    public float BaseCritChance { get => _baseCritChance; set => _baseCritChance = value; }
}
