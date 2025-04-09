using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

//Inputs de PC, en caso de que el juego sea tambien utilizado para mobile
public class PCInputs : InputHandler
{
    //No del todo implementados
    public static Action interactInput;
    public static Action click;

    public PCInputs(float sens)
    {
        _sens = sens;
        interactInput = null;
        click = null;

        UpdateInputs = NormalInputs;

        EventManager.SubscribeToEvent(EventsType.Event_BattleStart, ChangeToBattle);
        EventManager.SubscribeToEvent(EventsType.Event_BattleEnd, ChangeToNormal);
    }

    #region Type of Inputs
    private void NormalInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            click?.Invoke();
        }

        if (GameManager.isPaused) return;

        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        InputVector = new Vector2(h, v);

        float mouseX = Input.GetAxisRaw("Mouse X") * _sens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * -_sens;

        ScreenPosition = new Vector2(mouseY, mouseX);

        if (Input.GetKeyDown(KeyCode.E))
        {
            interactInput?.Invoke();
        }
    }

    private void BattleInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            click?.Invoke();
        }

        if (GameManager.isPaused) return;
        
        float mouseX = Input.GetAxisRaw("Mouse X") * _sens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * -_sens;

        ScreenPosition = new Vector2(mouseY, mouseX);

        if (Input.GetKeyDown(KeyCode.E))
        {
            interactInput?.Invoke();
        }
    }
    #endregion

    #region Change Inputs 
    private void ChangeInputs(PlayerState state)
    {
        switch (state)
        {
            case PlayerState.Normal:
                UpdateInputs = NormalInputs;
                break;
            case PlayerState.Battle:
                UpdateInputs = BattleInputs;
                InputVector = new Vector2(0, 0);
                break;
            default:
                break;
        }
    }
        
    private void ChangeToNormal(object a)
    {
        ChangeInputs(PlayerState.Normal);
    }
    
    private void ChangeToBattle(object a)
    {
        ChangeInputs(PlayerState.Battle);
    }
    #endregion
    
    /// <summary>
    /// Espera un input.
    /// </summary>
    /// <param name="key"> Tecla </param>
    /// <returns> Si el botón fue apretado o no. </returns>
    public static bool WaitForInput(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            return true;
        }
        return false;
    }
}
