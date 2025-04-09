using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SocialPlatforms;

// ReSharper disable once CheckNamespace
public enum Language
{
    English,
    Spanish
}
public class Localization : MonoBehaviour
{
    [SerializeField] private string webURL = "https://docs.google.com/spreadsheets/d/e/2PACX-1vTrZoqClc0pnwlySCcQH7RaaqZS9g8i37vW0OjykifesugFXqEbPwjRilPJjuoD7eL-5RdH1-OMQmGF/pub?output=csv";

    [SerializeField] private Language currentLanguage;

    private Dictionary<Language, Dictionary<string, string>> _languageCodex;
    
    public event Action OnLanguageChanged = delegate { };
    
    public static Localization Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        
        StartCoroutine(InitializeCodex());
    }

    IEnumerator InitializeCodex()
    {
        var www = new UnityWebRequest(webURL);
        
        www.downloadHandler = new DownloadHandlerBuffer();
        
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            var result = www.downloadHandler.text;

            _languageCodex = LanguageSplit.LoadCSV(result, "main menu sheet");
            
            OnLanguageChanged();
        }
    }

    public string GetTranslate(string id)
    {
        var idsDictionary = _languageCodex[currentLanguage];
        
        idsDictionary.TryGetValue(id, out var result);

        return result;
    }

    public void UpdateLanguages()
    {
        OnLanguageChanged();
    }
}
