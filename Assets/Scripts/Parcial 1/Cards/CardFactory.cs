using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Factory.Pool;
using System;

public class CardFactory : MonoBehaviour
{
    public static CardFactory Instance { get; private set; }
    public Dictionary<CardType, Factory<Card>> FactoryType { get; private set; }
    [SerializeField] private int cardAmount;
    [field: SerializeField] public Card[] cards;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
            return;
        }

        FactoryType = new();

        //Por cada tipo de carta a�adida al array "cards" crea una fabrica de ese tipo de carta
        for (int i = 0; i < cards.Length; i++)
        {
            var cardType = cards[i].cardType;
            var typeOfCard = cards[i].GetType();

            //Si esa fabrica ya fue creada, no hace nada. Previniendo crear multiples fabricas del mismo tipo de carta
            if (!FactoryType.ContainsKey(cardType))
            {
                var pool = new Pool<Card>(() => Instantiate(cards[i]),
                                   (card) => card.SetTableCard(),
                                   (card) => card.gameObject.SetActive(false),
                                   cardAmount);
                var cardFactory = new Factory<Card>(pool);

                FactoryType.Add(cardType, cardFactory);
                Debug.Log(i);
            }
        }
    }

    public Card GetObjectFromPool(CardType cardType)
    {
        if (FactoryType.TryGetValue(cardType, out var factory))
        {
            return factory.GetObjectFromPool();
        }
    
        return default;
    }

    public void ReturnObjectToPool(Card obj, CardType cardType)
    {
        if (FactoryType.TryGetValue(cardType, out var factory))
        {
            factory.ReturnObjectToPool(obj);
        }
    }
}
