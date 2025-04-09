using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInputs
{
    private Agent _agent;
    private Camera _cam;
    

    public BattleInputs(Camera cam, Agent agent)
    {
        _cam = cam;
        _agent = agent;
    }

    public void BattleUpdate()
    {
        RaycastCheck.CheckObjectInFront<IInteractable>(_cam, _agent);
    }
}
