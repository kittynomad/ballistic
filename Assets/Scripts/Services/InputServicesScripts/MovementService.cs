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
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _maxVelocity;

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
        
        if(!(rb.linearVelocity.magnitude > _maxVelocity))
            rb.AddForce(moveDirection * _movespeed);

        //using AddForce *and* MovePosition because that was the only way to get the movement feel i was looking for apparently

        rb.MovePosition(rb.transform.position + (_movespeed * moveDirection * Time.deltaTime / 25f));
    }

    public void JumpPlayer()
    {
        rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

}
