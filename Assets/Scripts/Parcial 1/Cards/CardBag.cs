using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBag
{
    [SerializeField] public List<Card> cardsList;
    public Agent Owner {get; private set;}

    public CardBag(Agent owner)
    {
        cardsList = new List<Card>();
        Owner = owner;
    }

    public void AddCard(Card card)
    {
        cardsList.Add(card);    
    }

    public int Holding<Card>()
    {
        var cardAmount = 0; 

        foreach (var type in cardsList)
        {
            if (type is Card)
            {
                cardAmount++;
            }
        }

        return cardAmount;
    }
}
