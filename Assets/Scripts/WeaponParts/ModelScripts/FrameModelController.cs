using UnityEngine;
using NaughtyAttributes;

public class FrameModelController : MonoBehaviour
{
    [SerializeField] private GameObject _batteryConnectionPoint;
    [SerializeField] private GameObject _magazineConnectionPoint;
    [SerializeField] private GameObject _muzzleConnectionPoint;
    [SerializeField] private GameObject[] _modifierConnectionPoints;

    [SerializeField] private PartModelController _testMuzzle;

    public void ConnectPart(PartModelController part, Vector3 connectionPoint)
    {
        part.transform.position = connectionPoint + part.PartConnectionPoint.transform.localPosition;
        part.transform.parent = transform;
    }

    [Button]
    public void TestAssembly()
    {
        ConnectPart(_testMuzzle, _muzzleConnectionPoint.transform.position);
    }
}
