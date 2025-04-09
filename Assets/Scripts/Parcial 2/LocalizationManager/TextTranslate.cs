using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextTranslate : MonoBehaviour
{
    [SerializeField] private string _id;

    [SerializeField] private TextMeshProUGUI _text;
    
     private Localization _localization;
     
    private void Start()
    {
        _localization = Localization.Instance;
        _localization.OnLanguageChanged += ChangeLanguage;
    }

    void ChangeLanguage()
    {
        _text.text = _localization.GetTranslate(_id);
    }
}
