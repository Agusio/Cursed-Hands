using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AgentMVC;

[DisallowMultipleComponent]
public abstract class Agent : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] protected string characterName, characterDesc;
    [SerializeField] protected float maxHp, currentHp, /*intelligenceLevel, maxMp, currentMp,*/ speed;
    public Transform orientation;

    /// <summary>
    /// MVC
    /// </summary>
    public AgentModel Model { get; protected set; }
    protected AgentView _view;
    protected AgentController _controller;

    /// <summary>
    /// used classes
    /// </summary>
    public Rigidbody Rigidbody { get; protected set; }
    public Animator Animator { get; protected set; }
    public Renderer Renderer { get; protected set; }
    public CardBag CardBag { get; protected set; }
    public InputHandler InputHandler { get; protected set; }    

    /// <summary>
    /// Values accessible through scritps
    /// </summary>
    public float StartHp { get; protected set; }
    public float Speed { get; protected set; }
    [field: SerializeField] public Image HpBarImage { get; protected set; }

    protected virtual void Awake()
    {
        StartHp = maxHp;
        Speed = speed;
        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
        Renderer = GetComponentInChildren<Renderer>();

        CardBag = new CardBag(this);

        Model = new AgentModel(this);
        _view = new AgentView(this);
        _controller = new AgentController(this);

        Model.HpComponent.OnHpChange += _view.UpdateHpBar;
        Model.HpComponent.OnDead += _view.DeadMaterial;
        Model.OnMovement += _view.MovementAnimation;

        Model.HpComponent.OnDead += DisableComponent;
    }

    //Deshabilita al morir
    void DisableComponent()
    {
        enabled = false;
    }
}
