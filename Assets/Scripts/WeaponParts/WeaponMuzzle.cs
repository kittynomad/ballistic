using UnityEngine;

[System.Serializable]
public class WeaponMuzzle : WeaponPart
{
    [SerializeField] private float _spread;
    [SerializeReference, AbstractSerializer] private ModifierDef mod;

    public float Spread { get => _spread; set => _spread = value; }
}
