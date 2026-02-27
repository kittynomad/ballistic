using UnityEngine;

public class PartModelController : MonoBehaviour
{
    [SerializeField] private GameObject _partConnectionPoint;

    public GameObject PartConnectionPoint { get => _partConnectionPoint; set => _partConnectionPoint = value; }
}
