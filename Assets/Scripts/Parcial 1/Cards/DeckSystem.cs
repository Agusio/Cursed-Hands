using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class DeckSystem
{
    [field: SerializeField] private List<Card> deck = new List<Card>();
    private static bool _playCard;
    public DeckSystem(List<Card> cards)
    {
        deck = new List<Card>();

        foreach (var card in cards)
        {
            deck.Add(card);
        }
    }

    public void ShuffleDeck()
    {
        deck = deck.OrderBy(card => Random.value).ToList();
    }

    public Card GetCard()
    {
        var card = deck.Last();
        deck.Remove(card);
        return card;
    }

    public Card PeekCard()
    {
        return deck.Last();
    }

    public static bool PlayCard()
    {
        return _playCard;
    }

    public static IEnumerator CardPlayed()
    {
        _playCard = true;
        _playCard = false;
        yield return null;
    }
}
