using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : Card
{
    public Agent owner;
    protected override void Awake()
    {
        base.Awake();
        
        ICardPower cardPower = new AttackPower(owner);
        ICardPower cardText = new TextCard("Ataque!");
        
        OnCardUse += cardPower.Power;
        OnCardUse += cardText.Power;
    }
}
