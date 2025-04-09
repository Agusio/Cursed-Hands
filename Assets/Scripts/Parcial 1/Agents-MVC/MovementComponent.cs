using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Componente de movimiento, puede utilizar inputs del Player o recibir un vector2 y moverse en caso de que sea otro Agent
public class MovementComponent
{
    private Transform _orientation;
    Rigidbody _rb;
    private float _speed;

    public MovementComponent(Agent agent)
    {
        _orientation = agent.orientation;
        _rb = agent.Rigidbody;
        _speed = agent.Speed;
    }

    private void Move(Vector2 direction)
    {
        Vector3 moveDirection = _orientation.forward * direction.y + _orientation.right * direction.x;

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

    public void MovementUpdate(Vector2 direction)
    {
        Move(direction);
        SpeedControl();
    }
}
