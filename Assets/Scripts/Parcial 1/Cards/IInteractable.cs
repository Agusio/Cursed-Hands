using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IInteractable
{
    public void Interact(Agent agent);
    
    public void Point();
    public void Unpoint();
}
