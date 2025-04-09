using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleTable : MonoBehaviour, IInteractable
{
    [SerializeField] private Agent tableAgent;
    [SerializeField] private List<Transform> playerCardPos, oponentCardPos;

    public void Interact(Agent agent)
    {
        StartBattle(agent);
    }

    public void Point()
    {
        
    }

    public void Unpoint()
    {

    }


    //Empieza la batalla al interactuar.
    private void StartBattle(Agent agent)
    {
        BattleSystem.Instance.SetUpBattle(agent, tableAgent, playerCardPos, oponentCardPos);
    }
}
