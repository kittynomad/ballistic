using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;

public class FrameModelController : MonoBehaviour
{
    [SerializeField] private GameObject _batteryConnectionPoint;
    [SerializeField] private GameObject _magazineConnectionPoint;
    [SerializeField] private GameObject _muzzleConnectionPoint;
    [SerializeField] private GameObject _backConnectionPoint;
    [SerializeField] private GameObject[] _modifierConnectionPoints;

    private List<PartModelController> attachedParts = new List<PartModelController>();

    [SerializeField] private PartModelController _testMuzzle;
    public void ConnectPart(PartModelController part, Vector3 connectionPoint)
    {
        part.transform.position = connectionPoint + part.PartConnectionPoint.transform.localPosition;
        part.transform.parent = transform;
        attachedParts.Add(part);
    }

    public void ConnectPart(PartModelController part, GameObject connectionPoint)
    {
        ConnectPart(part, connectionPoint.transform.position);
    }

    public void RemovePart(PartModelController part, bool destroyPart = true)
    {
        if(attachedParts.Contains(part))
        {
            attachedParts.Remove(part);
            part.transform.parent = null;
            if (destroyPart) Destroy(part.gameObject);
        }
    }

    [Button]
    public void TestRemovePart()
    {
        RemovePart(_testMuzzle, true);
    }

    [Button]
    public void TestAssembly()
    {
        ConnectPart(_testMuzzle, _muzzleConnectionPoint.transform.position);
    }
}
