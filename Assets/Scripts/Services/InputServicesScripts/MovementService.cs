/*****************************************************************************
// File Name : MovementService.cs
// Author : Pierce Nunnelley
// Creation Date : February 15, 2026
//
// Brief Description : This service behavior related to player movement input.
*****************************************************************************/
using UnityEngine;

public class MovementService : Service
{
    [SerializeField] private float _movespeed;

    private Vector2 movementVector = Vector2.zero;
    private PlayerBehaviors pb;
    private Rigidbody rb;

    public Vector2 MovementVector { get => movementVector; set => movementVector = value; }

    public override async Awaitable Initialize()
    {
        pb = FindAnyObjectByType<PlayerBehaviors>();
        rb = pb.gameObject.GetComponent<Rigidbody>();
        await base.Initialize();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 moveDirection = new Vector3(movementVector.x, 0f, movementVector.y);
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 flattened = Vector3.ProjectOnPlane(cameraForward, Vector3.up);
        Quaternion cameraOrientation = Quaternion.LookRotation(flattened);

        moveDirection = cameraOrientation * moveDirection;
        //Vector3 direction = (movementVector.x * rb.transform.right + movementVector.y * rb.transform.forward).normalized;
        rb.AddForce(moveDirection * _movespeed);
    }

}
