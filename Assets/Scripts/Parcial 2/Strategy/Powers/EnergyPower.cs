using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPower : ICardPower
{
    private TurnSystem _turnSystem;
    
    public EnergyPower()
    {
        _turnSystem = BattleSystem.Instance.TurnSystem;
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
        _turnSystem.NextTurn(true);
    }
}
