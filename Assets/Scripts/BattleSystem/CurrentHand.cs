using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentHand
{
    private List<Card> _cards;

    public CurrentHand(List<Card> cards)
    {
        _cards = new List<Card>();
        _cards = cards;
    }

    public void AddCard(Card card)
    {
        _cards?.Add(card);
    }

    public bool RemoveCard(Card card)
    {
        if (_cards?.Contains(card) == true)
        {
            _cards?.Remove(card);
            return true;
        }
        else
        {
            return false;
        }
    }
}
