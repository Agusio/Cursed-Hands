using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCard : ICardPower
{
    private string _text;
    
    public TextCard(string text)
    {
        _text = text;
    }
    
    public void Power()
    {
        TextChanger.cardText.text = _text;
    }
}
