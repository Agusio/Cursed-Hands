using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script solo utilizado por el player. Controla la camara en primera persona.
public class PlayerCam
{
    private Camera _cam;
    private Transform _orientation;
    private InputHandler _input;

    private float _xRotation;
    private float _yRotation;

    public PlayerCam(Player player)
    {
        _cam = player.cam;
        _orientation = player.orientation;
        _input = player.InputHandler;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void CameraUpdate()
    {
        _yRotation += _input.ScreenPosition.y;

        _xRotation += _input.ScreenPosition.x;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        _cam.transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        _orientation.rotation = Quaternion.Euler(0, _yRotation, 0);
    }
}
