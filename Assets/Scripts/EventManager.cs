using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

//Manejador de eventos, mas eventos seran agregados mas adelante y con mayor utilidad.
public enum EventsType
{
    Event_CardGrabbed,
    Event_BattleStart,
    Event_BattleEnd,
    Event_PlayerLost,
    Event_PlayerWon,
}

public class EventManager
{
    public delegate void MethodToSubscribe(params object[] parameters);

    static Dictionary<EventsType, MethodToSubscribe> _events;

    public static void SubscribeToEvent(EventsType eventsType, MethodToSubscribe methodToSubscribe)
    {
        if (_events == null) _events = new Dictionary<EventsType, MethodToSubscribe>();

        _events.TryAdd(eventsType, null);

        _events[eventsType] += methodToSubscribe;
    }

    public static void UnsubscribeToEvent(EventsType eventsType, MethodToSubscribe methodToUnsubscribe)
    {
        if (_events == null) return;

        if (!_events.ContainsKey(eventsType)) return;

        _events[eventsType] -= methodToUnsubscribe;
    }

    public static void TriggerEvent(EventsType eventsType, params object[] parameters)
    {
        if (_events == null) return ;

        if (!_events.ContainsKey (eventsType)) return ;

        if (_events[eventsType] == null) return;

        _events[eventsType](parameters);
    }
}
