using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class RaycastCheck
{
    private static IInteractable lastObject;
    
    //Chequea si un objeto es Interactuable y ejecuta un comando segun <T>.
    public static IInteractable CheckObjectInFront<T>(Camera cam, Agent agent)
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, 5))
        {
            var gameObject = hit.collider.gameObject;
            if (!gameObject.CompareTag("Object")) { return null; }
            if (hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
            {
                //Si el objeto interactuable actual no es el mismo que el anterior seleccionado, deselecciona este ultimo.
                if (lastObject != interactable && lastObject != null) lastObject.Unpoint();
                
                lastObject = interactable;
                interactable.Point();
                
                //El objeto interactuable reacciona a la posicion del cursor
                if(PCInputs.WaitForInput(KeyCode.E))
                {
                    interactable.Interact(agent);
                }
                return interactable;  
            }
        }
        
        //En caso de no estar sobre ningun objeto deselecciona el ultimo y lo iguala a null
        if (lastObject != null)
        {
            lastObject.Unpoint();
            lastObject = null;
        }
        return null;
    }

    // //Sin utilizar, probablemente lo eliminemos ya que hace lo mismo que el metodo de arriba.
    // public static bool CheckInteractuableObject(Camera cam, string tag)
    // {
    //     bool b = false;
    //     Ray ray = cam.ViewportPointToRay(Input.mousePosition);
    //     RaycastHit hit;
    //     if (Physics.Raycast(ray, out hit, 5))
    //     {
    //         if (hit.collider.gameObject.CompareTag(tag))
    //         {
    //             b = true;
    //         }
    //     }
    //     return b;
    // }
}