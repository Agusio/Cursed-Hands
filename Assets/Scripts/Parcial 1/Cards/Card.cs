using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public enum CardType
{
    Attack,
    Energy,
    Flame, 
    Premonition
};

//Tenemos planeado realizar un MVC para la carta, pero aun no fue implementado.
public abstract class Card : MonoBehaviour, IInteractable
{
    public event Action OnCardUse = delegate { };
    public event Action<CardBag> OnCardGrab = delegate { };

    [SerializeField] protected bool IsTableCard;
    [SerializeField] protected bool isUtilityCard;
    [SerializeField] public CardType cardType;
    
    private Material _mat;
    private Color _currentColor;

    protected CardBag OwnerBag;
    protected Agent Owner;

    protected virtual void Awake()
    {
        OnCardGrab += CollectCard;
        OnCardUse += UseCard;
        
        _mat = GetComponent<Renderer>().material;
        _currentColor = _mat.color;
    }

    //Guarda la carta en una CardBag (player u otro agent) para ser utilizada luego en BattleSystem
    public void CollectCard(CardBag ownerBag)
    {
        if (IsTableCard) return;
        if (OwnerBag != null) return;

        OwnerBag = ownerBag;
        OwnerBag.AddCard(this);
        SendBack();
    }

    //Manda la carta de vuelta al pool
    public void SendBack()
    {
        CardFactory.Instance.ReturnObjectToPool(this, this.cardType);
    }

    public void Interact(Agent agent)
    {
        if (!IsTableCard)
            OnCardGrab(agent.CardBag);
        else
            OnCardUse();
    }
    

    //Hace que la carta solamente pueda ser utilizada y no agarrada.
    public void SetTableCard()
    {
        IsTableCard = true;
        gameObject.SetActive(true);
    }
    
    public void UseCard()
    {
        
    }

    #region HoverOver
    private void Glow(bool b)
    {
        //Effects
        if (b)
            _mat.color = Color.green;
        else 
            _mat.color = _currentColor;
    }

    public void Point() { Glow(true);  }

    public void Unpoint() { Glow(false); }

    #endregion
}
