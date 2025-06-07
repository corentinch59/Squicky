using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRadius = 2f;

    
    public void Interact(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;
        
        Collider[] hits = Physics.OverlapSphere(transform.position, interactionRadius);
        
        foreach (var hit in hits)
        {
            IInteract interactable = hit.GetComponent<IInteract>();
            if (interactable != null)
            {
                interactable.Interact(gameObject);
                break;
            }
        }
    }
    
    
}
