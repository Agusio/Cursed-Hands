using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private ScreenUI _mainMenu;
    [SerializeField] private ScreenUI _settingsMenu;
    [SerializeField] private ScreenUI _creditsMenu;

     private void Start()
     {
         var main = _mainMenu;
         
         ScreenManager.Instance.Push(_mainMenu);
     }

     public void StartGame()
    {
        SceneManager.LoadScene("GameTest");
    }

    public void SettingsMenuButton()
    {
        ScreenManager.Instance.Push(_settingsMenu);
        Localization.Instance.UpdateLanguages();
    }

    public void MainMenuButton()
    {
        ScreenManager.Instance.Pop();
        Localization.Instance.UpdateLanguages();
    }

    public void CreditsMenuButton()
    {
        ScreenManager.Instance.Push(_creditsMenu);
        Localization.Instance.UpdateLanguages();
    }
}

