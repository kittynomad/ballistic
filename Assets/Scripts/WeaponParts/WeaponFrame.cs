using UnityEngine;

[System.Serializable]
public class WeaponFrame : WeaponPart
{
    [SerializeField] private float _fireVelocity = 1f;
    [SerializeField] private int _addonCapacity = 3;
    [SerializeField] private float _baseCritChance = 10f;

    public float FireVelocity { get => _fireVelocity; set => _fireVelocity = value; }
    public int AddonCapacity { get => _addonCapacity; set => _addonCapacity = value; }
    public float BaseCritChance { get => _baseCritChance; set => _baseCritChance = value; }
}
