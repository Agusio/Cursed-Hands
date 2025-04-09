using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenUI : MonoBehaviour, IScreen
{
    private Button[] _buttons;

    [SerializeField] private bool _dissapearWhenDeactivated;

    private void Awake()
    {
        _buttons = GetComponentsInChildren<Button>(true);
        
        ActivateButtons(true);
        
        //gameObject.SetActive(true);
    }

    void ActivateButtons(bool enableBool)
    {
        foreach (var button in _buttons)
        {
            button.interactable = enableBool;
        }
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        
        ActivateButtons(true);
    }

    public void Deactivate()
    {
        if (_dissapearWhenDeactivated)
        {
            gameObject.SetActive(false);
        }
        ActivateButtons(false);
    }

    public void Release()
    {
        gameObject.SetActive(false);
    }
}
