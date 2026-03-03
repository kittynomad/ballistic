using UnityEngine;

[System.Serializable]
public class WeaponFrame : WeaponPart
{
    [SerializeField] private float _fireVelocity = 1f;

    public float FireVelocity { get => _fireVelocity; set => _fireVelocity = value; }
}
