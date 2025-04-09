using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

[SuppressMessage("ReSharper", "CheckNamespace")]
public enum SceneType
{
    MainMenu,
    Settings,
    Audio,
    Credits,
    Gameplay
}

public class UISceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject[] uiLoad;
    
    private readonly Dictionary<SceneType, GameObject> _uiDictionary = new();

    private GameObject _currentUI;
    
    public static UISceneLoader Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        
        for (int i = 0; i < uiLoad.Length; i++)
        {
            _uiDictionary.Add((SceneType)i, uiLoad[i]);
        }
        
        _currentUI = uiLoad[0];
        _currentUI.SetActive(true);
    }

    public void UpdateUI(SceneType sceneType)
    {
        _currentUI.SetActive(false);

        _uiDictionary.TryGetValue((SceneType)sceneType, out var uiObject);
        _currentUI = uiObject;
        
        if (_currentUI) 
            _currentUI.SetActive(true);
    }
}