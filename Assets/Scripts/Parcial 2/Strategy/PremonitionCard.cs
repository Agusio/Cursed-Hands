using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PremonitionCard : Card
{
    protected override void Awake()
    {
        base.Awake();
        
        ICardPower cardPower = new PremonitionPower();
        ICardPower cardText = new TextCard("Premonicion! No ocurre nada...");
        
        OnCardUse += cardText.Power;
        OnCardUse += cardPower.Power;
    }
}
