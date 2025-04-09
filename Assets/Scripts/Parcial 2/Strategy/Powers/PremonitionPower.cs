using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PremonitionPower : ICardPower
{
    private TurnSystem _turnSystem;
    
    public PremonitionPower()
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
        //No funciona por ahora al no haber Main Deck
        //var c = _turnSystem.MainDeck.PeekCard();
        Debug.Log("La siguiente carta es: ....");
    }
}
