using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRadius = 2f;
    [SerializeField] private Transform _headSpot;
    [SerializeField] private LayerMask _layerMask;

    public Transform GetHeadSpot {  get { return _headSpot; } }

    private GameObject _interactable;

    public GameObject HeldInteractable { set { _interactable = value; } }

    public void Interact(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (_interactable == null)
            {
                //Pickup
                Collider[] hits = Physics.OverlapSphere(transform.position, interactionRadius, _layerMask);

                if (hits.Length <= 0)
                    return;

                float d = (hits[0].transform.position - transform.position).sqrMagnitude;
                GameObject temp = hits[0].gameObject;

                foreach (var hit in hits)
                {
                    float tempD = (hit.transform.position - transform.position).sqrMagnitude;
                    if (tempD < d)
                    {
                        d = tempD;
                        temp = hit.gameObject;
                        //TODO ajouter une UI pour indiquer avec quel Interactable on interagit
                    }
                }


                if (temp != null)
                {
                    IInteractable interactable = temp.GetComponent<IInteractable>();
                    interactable.Interact(gameObject);
                }
            }
            else
            {
                //Use
                IDropable dropable = _interactable.GetComponent<IDropable>();
                if (dropable != null)
                {
                    dropable.Use(gameObject);
                }
            }

        }
    }

    public void Drop(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            _interactable.GetComponent<IDropable>().Drop();
            _interactable = null;
        }
    }
}
