using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextChanger : MonoBehaviour
{
    //Solo para probar que funcionan las cartas

    public static TextMeshProUGUI hpText;
    public static TextMeshProUGUI cardText;
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private TextMeshProUGUI _cardText;

    private void Awake()
    {
        hpText = _hpText;
        cardText = _cardText;
    }
}
