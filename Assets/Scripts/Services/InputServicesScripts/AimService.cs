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
    [SerializeField] private float _sensitivity = 1f;

    private Vector2 lookVector = Vector2.zero;
    private float pitch = 0f;
    private Rigidbody rb;

    public Vector2 LookVector { get => lookVector; set => lookVector = value; }

    public override async Awaitable Initialize()
    {
        rb = FindAnyObjectByType<PlayerBehaviors>().gameObject.GetComponent<Rigidbody>();
        await base.Initialize();
    }

    private void FixedUpdate()
    {
        Camera.main.transform.Rotate(Vector3.up, lookVector.x);
        rb.transform.Rotate(Vector3.up, lookVector.x);
        pitch -= lookVector.y;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        Camera.main.transform.localEulerAngles = new Vector3(pitch, Camera.main.transform.localEulerAngles.y, 0f);
        //Camera.main.transform.Rotate(Vector3.right, lookVector.y);
    }
}
