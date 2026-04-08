/*****************************************************************************
// File Name : AimService.cs
// Author : Pierce Nunnelley
// Creation Date : February 15, 2026
//
// Brief Description : This service handles player aiming behavior.
*****************************************************************************/
using UnityEngine;

public class AimService : Service
{
    [SerializeField] private float _sensitivity = 0.25f;

    private Vector2 lookVector = Vector2.zero;
    private float pitch = 0f;
    private Rigidbody rb;
    private float _cameraDistanceFromBody = 0.5f;
    private float _cameraHeight = 0.5f;

    public Vector2 LookVector { get => lookVector; set => lookVector = value; }

    public override async Awaitable Initialize()
    {
        rb = FindAnyObjectByType<PlayerBehaviors>().gameObject.GetComponent<Rigidbody>();
        await base.Initialize();
    }

    private void FixedUpdate()
    {
        Camera.main.transform.Rotate(Vector3.up, lookVector.x * _sensitivity);
        //rb.transform.Rotate(Vector3.up, lookVector.x * _sensitivity);
        pitch -= lookVector.y * _sensitivity;
        pitch = Mathf.Clamp(pitch, -80f, 80f);
        Vector3 camFlattenedForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);
        Camera.main.transform.localEulerAngles = new Vector3(pitch, Camera.main.transform.localEulerAngles.y, 0f);
        Camera.main.transform.localPosition = Vector3.Normalize(camFlattenedForward) * _cameraDistanceFromBody;
        Camera.main.transform.localPosition = new Vector3(Camera.main.transform.localPosition.x, _cameraHeight, Camera.main.transform.localPosition.z);
        //Camera.main.transform.Rotate(Vector3.right, lookVector.y);
    }
}
