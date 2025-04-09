using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : IMovement
{
    private Transform _orientation;
    Rigidbody _rb;
    private float _speed;

    private InputHandler _inputHandler;

    public PlayerMovement(Player player)
    {
        _orientation = player.orientation;
        _rb = player.Rigidbody;
        _inputHandler = player.InputHandler;
        _speed = player.Speed;
        //rb.drag = gd;
        Debug.Log("Initialized");
    }

    private void Move()
    {
        Vector3 moveDirection = _orientation.forward * _inputHandler.InputVector.y + _orientation.right * _inputHandler.InputVector.x;

        _rb.AddForce(_speed * 10f * moveDirection.normalized, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new(_rb.velocity.x, 0f, _rb.velocity.z);

        if (flatVel.magnitude > _speed)
        {
            Vector3 limitedVel = flatVel.normalized * _speed;
            _rb.velocity = new Vector3(limitedVel.x, _rb.velocity.y, limitedVel.z);
        }
    }

    public void MovementUpdate()
    {
        Move();
        SpeedControl();
    }
}
