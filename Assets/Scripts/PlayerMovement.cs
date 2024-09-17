using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Character Info
    public float moveSmoothTime, gravityStrength, jumpStrength, walkSpeed, runSpeed;
    
    private CharacterController _controller;
    private Vector3 _currentMoveVelocity;
    private Vector3 _moveDampVelocity;

    private Vector3 _currentForceVelocity;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 playerInput = new Vector3
        {
            x = Input.GetAxis("Horizontal"),
            y = 0f,
            z = Input.GetAxis("Vertical")
        };

        if (playerInput.magnitude > 1f)
        {
            playerInput.Normalize();
        }

        Vector3 moveVector = transform.TransformDirection(playerInput);
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        
        _currentMoveVelocity = Vector3.SmoothDamp(_currentMoveVelocity, moveVector * currentSpeed, ref _moveDampVelocity, moveSmoothTime);
        
        _controller.Move(_currentMoveVelocity * Time.deltaTime);
        
        Ray groundCheckRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(groundCheckRay, 1.25f))
        {
            _currentForceVelocity.y = -2f;

            if (Input.GetKey(KeyCode.Space))
            {
                _currentForceVelocity.y = jumpStrength;
            }
        }
        else
        {
            _currentForceVelocity.y -= gravityStrength * Time.deltaTime;
        }
        
        _controller.Move(_currentForceVelocity * Time.deltaTime);
    }
    
}
