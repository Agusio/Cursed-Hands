using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem
{
    private int _turnCount;
    private int _currentTurn;
    
    //private int _currentRound;

    private Agent _player;
    private Agent _opponent;
    private Agent _currentAgent;

    private DeckSystem _playerDeck, _opponentDeck, _mainDeck;
    public DeckSystem MainDeck { get { return _mainDeck; } }
    private CurrentHand _playerHand, _opponentHand;
    
    public TurnSystem(Agent player, Agent opponent, List<Card> mainDeck)
    {
        _player = player;
        _opponent = opponent;
        _currentAgent = _player;

        //_currentRound = 0;
        
        SetUpTurns();
        _playerDeck = new DeckSystem(player.CardBag.cardsList);
        _opponentDeck = new DeckSystem(opponent.CardBag.cardsList);
        _mainDeck = new DeckSystem(mainDeck);
        _playerHand = new CurrentHand(null);
        _playerHand = new CurrentHand(null);
    }

    private void SetUpTurns()
    {
        // _currentTurn = 0;
        // _turnCount = Random.Range(2, 7);
        // _currentRound += 1;
        //
        // //_mainDeck.ShuffleDeck();
        //
        // var utilityCardAmount = Random.Range(1, 4);
        // for (int i = 0; i < utilityCardAmount; i++)
        // { 
        //     _playerHand.AddCard(_playerDeck.GetCard());
        //     _opponentHand.AddCard(_opponentDeck.GetCard());
        // }
    }

    public void NextTurn(bool b)
    {
        _currentTurn += 1;
        if (_currentTurn == _turnCount)
        {
            SetUpTurns();
        }

        if (b)
        {
            Turn(_currentAgent);
        }

        if (_currentAgent == _player)
        {
            Turn(_opponent);
        }
        else if (_currentAgent == _opponent)
        {
            Turn(_player);
        }
    }

    private IEnumerator Turn(Agent currentAgent)
    {
        _currentAgent = currentAgent;
        while (true)
        {
            if (_currentAgent == _opponent)
            {
                var c = _mainDeck.GetCard();
                c.UseCard();
                NextTurn(false);
                break;
            }
            else if (_currentAgent == _player)
            {
                yield return new WaitUntil(DeckSystem.PlayCard);
                
                NextTurn(false);
                break;
            }
            yield return null;
        }
    }
}
