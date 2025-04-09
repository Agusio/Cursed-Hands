using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBattle : IScreen
{
    private Transform _root;

    private Camera _cam;
    private Transform _camPos;

    private Dictionary<Behaviour, bool> _beforeDeactivation;

    public ScreenBattle(Transform root, Transform camPos)
    {
        _root = root;
        _cam = Camera.main;
        _camPos = camPos;
        
        _beforeDeactivation = new Dictionary<Behaviour, bool>();
    }
    
    public void Activate()
    {
        _root.gameObject.SetActive(true);
        _cam.transform.position = _camPos.position;
        _cam.transform.rotation = _camPos.rotation;
        
        foreach (var pair in _beforeDeactivation)
        {
            pair.Key.enabled = pair.Value;
        }
    }

    public void Deactivate()
    {
        foreach (var behaviour in _root.GetComponentsInChildren<Behaviour>())
        {
            _beforeDeactivation[behaviour] = behaviour.enabled;
            
            behaviour.enabled = false;
        }
    }

    public void Release()
    {
        _root.gameObject.SetActive(false);  
    }
}
