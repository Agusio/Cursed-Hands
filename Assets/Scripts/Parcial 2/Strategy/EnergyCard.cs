using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCard : Card
{
    protected override void Awake()
    {
        base.Awake();
        
        ICardPower cardText = new TextCard("Energia! No ocurre nada...");
        
        OnCardUse += cardText.Power;
    }
}
