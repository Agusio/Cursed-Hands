using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePower : ICardPower
{
    private TurnSystem _turnSystem;
    private Agent _owner;
    
    public FlamePower(Agent owner)
    {
        _turnSystem = BattleSystem.Instance.TurnSystem;
        _owner = owner;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Power();
        }
    }

    public void Power()
    {
        //var c =_turnSystem.MainDeck.GetCard();
        //Debug.Log(c);
    }
}
