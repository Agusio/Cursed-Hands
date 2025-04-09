using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSelection : MonoBehaviour
{
    [SerializeField] private Transform _mainGameplay;
    [SerializeField] private Transform _battleGameplay;
    [SerializeField] private Transform _mainCamPos;
    [SerializeField] private Transform _battleCamPos;

    [SerializeField] private ScreenUI _pauseMenu;

    private void Start()
    {
        var main = new ScreenMain(_mainGameplay, _mainCamPos);
        
        ScreenManager.Instance.Push(main);
        
        EventManager.SubscribeToEvent(EventsType.Event_BattleStart, SetBattleScreen);
        EventManager.SubscribeToEvent(EventsType.Event_BattleEnd, SetMainScreen);
    }

    void SetMainScreen(params object[] objs)
    {
        var main = new ScreenMain(_mainGameplay, _mainCamPos);

        ScreenManager.Instance.Push(main);
    }

    void SetBattleScreen(params object[] objs)
    {
        var battle = new ScreenBattle(_battleGameplay, _battleCamPos);

        ScreenManager.Instance.Push(battle);
    }
}

