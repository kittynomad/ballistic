/*****************************************************************************
// File Name : FrameModelController.cs
// Author : Pierce Nunnelley
// Creation Date : February 28, 2026
//
// Brief Description : This script controls the model for a weapon's frame's
// 3D model. It includes functions for attaching models for other weapon parts,
// using "connection points" on both models to ensure models of differing
// sizes fit properly onto the frame.
*****************************************************************************/

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

    public GameObject BatteryConnectionPoint { get => _batteryConnectionPoint; set => _batteryConnectionPoint = value; }
    public GameObject MagazineConnectionPoint { get => _magazineConnectionPoint; set => _magazineConnectionPoint = value; }
    public GameObject MuzzleConnectionPoint { get => _muzzleConnectionPoint; set => _muzzleConnectionPoint = value; }
    public GameObject BackConnectionPoint { get => _backConnectionPoint; set => _backConnectionPoint = value; }
    public GameObject[] ModifierConnectionPoints { get => _modifierConnectionPoints; set => _modifierConnectionPoints = value; }

    public void ConnectPart(PartModelController part, Vector3 connectionPoint)
    {
        part.transform.parent = transform;
        part.transform.localPosition = connectionPoint - part.PartConnectionPoint.transform.localPosition;
        
        attachedParts.Add(part);
    }

    public void ConnectPart(PartModelController part, GameObject connectionPoint)
    {
        ConnectPart(part, connectionPoint.transform.localPosition);
    }

    public void ConnectPart(GameObject prefab, GameObject connectionPoint)
    {
        GameObject temp = Instantiate(prefab);
        ConnectPart(temp.GetComponent<PartModelController>(), connectionPoint);
    }

    public void DestroyModel()
    {
        /*while(attachedParts.Count > 0)
        {
            RemovePart(attachedParts[0], true);
        }*/
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
        Destroy(gameObject);
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
}
