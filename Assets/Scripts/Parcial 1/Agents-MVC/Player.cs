using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum PlayerState
{
    Normal,
    Battle
}
//El player, tiene sus propios inputs y Camara.
public class Player : Agent
{
    private PlayerCam _playerCam;
    private MoveCamera _moveCamera;

    [SerializeField] private Card[] cards;

    [Header("Camera")]
    [SerializeField] public Camera cam;
    [SerializeField] public Transform cameraHolder, cameraPos;
    [SerializeField] private float sens = 200;
    
    protected override void Awake()
    {
        InputHandler = new PCInputs(sens);
        _playerCam = new PlayerCam(this);
        _moveCamera = new MoveCamera(this);

        base.Awake();

        foreach (var card in cards)
        {
            CardBag.AddCard(card);
        }
    }

    void Update()
    {
        //var b = RaycastCheck.CheckObjectInFront<Card>(cam, this);
        RaycastCheck.CheckObjectInFront<IInteractable>(cam, this);
        _playerCam.CameraUpdate();
        _moveCamera.MoveCameraUpdate();
        InputHandler.UpdateInputs();
    }

    private void FixedUpdate()
    {
        Model.Movement.MovementUpdate(InputHandler.InputVector);
    }
}
