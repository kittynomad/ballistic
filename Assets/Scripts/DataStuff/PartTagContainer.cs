using UnityEngine;

[System.Serializable]
public struct PartTagContainer
{
    [SerializeReference, AbstractSerializer] private PartCategoryTag _partCategory;

    public PartCategoryTag PartCategory { get => _partCategory; set => _partCategory = value; }
}
