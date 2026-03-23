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
    [SerializeField] private Vector3[] assemblyCameraTransformVars;
    [SerializeField] private Vector3[] assembledCameraTransformVars;
    private Camera assemblyPreviewCamera;
    private Vector3 assemblyCameraOffset = new Vector3(6f, 0f, 0f);
    public override async Awaitable Initialize()
    {
        GameObject temp = Instantiate(Resources.Load("UI/AssemblyPreviewCamera") as GameObject);
        assemblyPreviewCamera = temp.GetComponent<Camera>();
        SetAssemblyModeCamera();
        SetGameplayModeCamera();
        await base.Initialize();
    }

    public void SetAssemblyModeCamera()
    {
        GameObject temp = assemblyPreviewCamera.gameObject;
        temp.transform.position = AssemblyUIService.VIEWMODEL_POSITION + assemblyCameraTransformVars[0];
        temp.transform.localEulerAngles = assemblyCameraTransformVars[1];
    }
    public void SetGameplayModeCamera()
    {
        GameObject temp = assemblyPreviewCamera.gameObject;
        temp.transform.position = AssemblyUIService.VIEWMODEL_POSITION + assembledCameraTransformVars[0];
        temp.transform.localEulerAngles = assembledCameraTransformVars[1];
    }
}
