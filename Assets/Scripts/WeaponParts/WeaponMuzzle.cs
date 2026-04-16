using UnityEngine;

[System.Serializable]
public class WeaponMuzzle : WeaponPart
{
    [Tooltip("The amount which a fired projectile may deviate from the target, in degrees. (this does not account for gravity).")]
    [SerializeField] private float _spread;

    public float Spread { get => _spread; set => _spread = value; }
}
