using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class ClientDebugger : MonoBehaviour
// {
//     [SerializeField] private Transform _mainGameplay;
//     [SerializeField] private Transform _cardGameplay;
//
//     [SerializeField] private ScreenUI _pauseMenu;
//
//     private void Awake()
//     {
//         var main = new ScreenMain(_mainGameplay);
//         
//         ScreenManager.Instance.Push(main);
//     }
//
//     void Update()
//     {
//
//         if (Input.GetKeyDown(KeyCode.Space))
//         {
//             ScreenManager.Instance.Push(new ScreenMain(Instantiate(_cardGameplay)));
//         }
//         else if (Input.GetKeyDown(KeyCode.P))
//         {
//             if (_pauseMenu.gameObject.activeSelf) return;
//             
//             ScreenManager.Instance.Push(_pauseMenu);
//         }
//         else if (Input.GetKeyDown(KeyCode.Escape))
//         {
//             ScreenManager.Instance.Pop();
//         }
//
//     }
// }
