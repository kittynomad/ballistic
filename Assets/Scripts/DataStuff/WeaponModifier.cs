using UnityEngine;

[System.Serializable]
public struct WeaponModifier
{
    [SerializeField] private Enums.Modifiers _modType;
    [SerializeField] private Enums.Operators _modOperator;
    [SerializeField] private float _modStrength;

    public Enums.Modifiers ModType { get => _modType; set => _modType = value; }
    public Enums.Operators ModOperator { get => _modOperator; set => _modOperator = value; }
    public float ModStrength { get => _modStrength; set => _modStrength = value; }
}
