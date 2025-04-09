using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.DecisionTree;

public class Opponent : Agent
{
    //Oponente basico, no tiene ningun funcionamiento mas que poner cartas en la mesa.
    [SerializeField] private Card[] cards; 

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        foreach (var card in cards)
        {
            CardBag.AddCard(card);
        }
    }

    public void Turn()
    {
        //Do turn
    }
    
    #region DecisionTree
    private void SetUpDecisionTree()
    {

    }
    #endregion
}
