using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static bool isPaused = false;
    public static bool isInBattle = false;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        EventManager.SubscribeToEvent(EventsType.Event_BattleStart, BattleStatus);
        EventManager.SubscribeToEvent(EventsType.Event_BattleEnd, BattleStatus);
        Application.targetFrameRate = 30;
    }

    //En evento de pausa (no agregado aun) 
    private void PauseSwitch()
    {
        if (isPaused)
            isPaused = false;
        else 
            isPaused = true; 
    }

    //En evento de batalla.
    private void BattleStatus(object a = null)
    {
        if (isInBattle)
            isInBattle = false;
        else 
            isInBattle = true;
    }
}
