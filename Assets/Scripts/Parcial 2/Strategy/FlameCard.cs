using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameCard : Card
{
    protected override void Awake()
    {
        base.Awake();
        
        ICardPower flameCardPower = new FlamePower(Owner);
        ICardPower cardText = new TextCard("Fuego! No ocurre nada...");
        
        OnCardUse += cardText.Power;
        OnCardUse += flameCardPower.Power;
    }
}
