using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPower : ICardPower
{
    private BattleSystem _battleSystem;
    private Agent _owner;
    public AttackPower(Agent owner)
    {
        _battleSystem = BattleSystem.Instance;
        _owner = owner;
    }
    
    public void Power()
    {
        if (_battleSystem.Player == _owner)
        {
            _battleSystem.Oponent.Model.HpComponent.TakeDamage(1);
        }
        else if (_battleSystem.Oponent == _owner)
        {
            _battleSystem.Player.Model.HpComponent.TakeDamage(1);
        }
    }
}
