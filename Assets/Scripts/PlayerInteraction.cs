using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRadius = 2f;

    private GameObject _interactable;

    public void Interact(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (_interactable != null)
            {
                //Pickup
                Collider[] hits = Physics.OverlapSphere(transform.position, interactionRadius);

                float d = 0;
                GameObject temp = null;

                foreach (var hit in hits)
                {
                    float tempD = (hit.transform.position - hit.transform.position).sqrMagnitude;
                    if (tempD < d)
                    {
                        d = tempD;
                        _interactable = hit.gameObject;
                        //TODO ajouter une UI pour indiquer avec quel Interactable on interagit
                    }
                }

                Interactable interactable = _interactable.GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.PickUpInteractable(gameObject);
                }
            }
            else
            {
                //Use
                Interactable interactable = _interactable.GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.PickUpInteractable(gameObject);
                }
            }

        }
    }

    public void Drop()
    {

    }
}
