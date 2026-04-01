using UnityEngine;

[System.Serializable]
public class WeaponMuzzle : WeaponPart
{
    [SerializeField] private float _spread;
    [SerializeReference] public ModifierDef _def;

    public float Spread { get => _spread; set => _spread = value; }
}
