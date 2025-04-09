using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Componente de vida, aún no utilizado, pero será utilizado más adelante.
public class HpComponent
{
    private float _maxHp = 5;
    private float _currentHp;

    public event Action<float> OnHpChange = delegate { };  

    public event Action OnDead = delegate { };

    public float CurrentHp => _currentHp;

    public HpComponent(float startHp)
    {
        _currentHp = _maxHp = startHp;
    }

    public void TakeDamage(int dmg)
    {
        _currentHp -= dmg;

        OnHpChange(_currentHp / _maxHp);

        TextChanger.hpText.text = "Vida restante: " + _currentHp;

        if (_currentHp <= 0 )
        {
            OnDead();
            _currentHp = _maxHp;
        }
    }

    public void Heal(int heal)
    {
        _currentHp += heal;
        
        OnHpChange(_currentHp / _maxHp);

        Debug.Log("Current HP" + _currentHp);

        if (_currentHp > 5 )
        {
            _currentHp = 5;
            Debug.Log("HP already max");
        }
    }
}
