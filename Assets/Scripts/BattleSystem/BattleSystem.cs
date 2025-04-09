using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum BattleState{ START, PLAYERTURN, ENEMYTURN, END }
public class BattleSystem : MonoBehaviour
{
    public static BattleSystem Instance { get; private set; }
    private CardFactory _cardFactory;
    private ScreenManager _screenManager;

    private List<Card> _cardsInPlay;
    
    private Agent _player, _oponent;
    public Agent Player { get { return _player; } }
    public Agent Oponent { get { return _oponent; } }

    private TurnSystem _turnSystem;
    public TurnSystem TurnSystem { get { return _turnSystem; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        _screenManager = ScreenManager.Instance;
        _cardFactory = CardFactory.Instance;
    }

    private void Update()
    {
        //Al no haber condiciones de victoria ni derrota, este input es la única forma de terminarla, no es permanente.
        if (Input.GetKeyDown(KeyCode.P))
        {
            BattleEnd();
        }
    }

    #region Set Up Battle
    /// <summary>
    /// Comienza la batalla, requiere dos Agent, jugador y oponente, y las posiciones de las cartas en la mesa (esto último probablemente cambie).
    /// Por cada carta que cada Agent lleva las coloca en la mesa que ejecuto este método.
    /// </summary>
    /// <param name="player">Agent del player</param>
    /// <param name="opponent">Agent del oponente brindado por la mesa</param>
    /// <param name="playerPos">Posición de las cartas del player</param>
    /// <param name="oponentPos">Posición de las cartas del oponente</param>
    public void SetUpBattle(Agent player, Agent opponent, List<Transform> playerPos, List<Transform> oponentPos)
    {
        if (GameManager.isInBattle) { return; }
        EventManager.TriggerEvent(EventsType.Event_BattleStart);
        _turnSystem = new TurnSystem(player, opponent, new List<Card>(opponent.CardBag.cardsList));
        _cardsInPlay = new List<Card>();
        
        _player = player;
        _oponent = opponent;
        
        _player.Model.HpComponent.OnDead += PlayerLost;
        _oponent.Model.HpComponent.OnDead += PlayerWon;
    }
    #endregion

    #region BattleEnd
    //Activa los eventos.
    private void PlayerWon()
    {
        EventManager.TriggerEvent(EventsType.Event_PlayerWon);
        BattleEnd();
    }

    private void PlayerLost()
    {
        EventManager.TriggerEvent(EventsType.Event_PlayerLost);
        BattleEnd();
    }

    //Manda las cartas de vuelta al pool al terminar la batalla.
    private void BattleEnd()
    {
        EventManager.TriggerEvent(EventsType.Event_BattleEnd);

        foreach (var tableCard in _cardsInPlay)
        {
            tableCard.SendBack();
        }
    }
    #endregion
}
