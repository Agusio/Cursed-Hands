using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script solo utilizado por el player, mueve la camara a su posicion.
public class MoveCamera
{
    private Transform _cameraHolder;
    private Transform _cameraPos;

    public MoveCamera(Player player)
    {
        _cameraHolder = player.cameraHolder;
        _cameraPos = player.cameraPos;
    }

    public void MoveCameraUpdate()
    {
        _cameraHolder.SetPositionAndRotation(_cameraPos.position, _cameraPos.rotation);
    }
}
