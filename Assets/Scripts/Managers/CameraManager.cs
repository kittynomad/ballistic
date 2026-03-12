/*****************************************************************************
// File Name : CameraManager.cs
// Author : Pierce Nunnelley
// Creation Date : February 13, 2026
//
// Brief Description : This script manages camera behavior and functions.
*****************************************************************************/
using UnityEngine;

public class CameraManager : Manager
{
    private Camera assemblyPreviewCamera;
    private Vector3 assemblyCameraOffset = new Vector3(6f, 0f, 0f);
    public override async Awaitable Initialize()
    {
        GameObject temp = Instantiate(Resources.Load("UI/AssemblyPreviewCamera") as GameObject);
        assemblyPreviewCamera = temp.GetComponent<Camera>();
        temp.transform.position = AssemblyUIService.VIEWMODEL_POSITION + assemblyCameraOffset;
        await base.Initialize();
    }
}
