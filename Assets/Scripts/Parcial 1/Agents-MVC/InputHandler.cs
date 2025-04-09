using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public abstract class InputHandler
{
    public Vector2 InputVector { get; protected set; }
    public Vector2 ScreenPosition { get; protected set; }

    protected float _sens;

    public Action UpdateInputs = delegate { };
}
