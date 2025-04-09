using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

// public class BattleAgent
// {
//     private int _maxHp;
//     private int _currentHp;
//     private string _name;
//
//     public event Action OnDead = delegate { };
//
//     public BattleAgent(Agent agent)
//     {
//         agent.Model.HpComponent.
//     }
//
//     public void Damage(int multiplier)
//     {
//         _currentHp -= multiplier;
//         if (_currentHp <= 0)
//         {
//             OnDead?.Invoke();
//         }
//     }
//
//     public void Heal()
//     {
//         _currentHp++;
//         if (_currentHp > _maxHp)
//         {
//             _currentHp = _maxHp;
//             Debug.Log("La vida ya esta al maximo");
//         }
//         //Heal effects
//     }
// }
