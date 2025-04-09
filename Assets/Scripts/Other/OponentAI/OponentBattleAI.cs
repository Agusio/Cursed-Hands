using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.DecisionTree;

public class OponentBattleAI : MonoBehaviour
{
    private Agent _oponent;
    private CardBag _oponentCardbag;
    private DecisionTree _decisionTree;
    private Card chosedCard;

    public OponentBattleAI(Agent self)
    {
        _oponent = self;
        _oponentCardbag = self.CardBag;

        //_oponent.Model.HpComponent.OnHpChange += CheckHP;
    }

    private void CheckHP()
    {

    }

    public int CurrentHP()
    {
        return default;
    }

    private void SetUpDecisionTree()
    {
        var playCard = new ActionNode(CheckHP);

        var hasAttackCard = new BinaryDecisionNode(playCard, playCard, HasCard<FlameCard>);
        _decisionTree = new(hasAttackCard);
    }

    public bool HasCard<Card>()
    {
        if (_oponentCardbag.Holding<Card>() > 0)
        {
            
        }
        return default;
    }

    public void UseCard<Card>(Card card)
    {
        //_oponentCardbag.
    }
}
