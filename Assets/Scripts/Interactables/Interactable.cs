using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour, IInteract
{
    [SerializeField] private UnityEvent<GameObject> _onInteract;

    public event UnityAction<GameObject> OnTryInteract
    {
        add => _onInteract.AddListener(value);
        remove => _onInteract.RemoveListener(value);
    }

    [SerializeField] private UnityEvent<GameObject> _onPickup;

    public event UnityAction<GameObject> OnPickup
    {
        add => _onPickup.AddListener(value);
        remove => _onPickup.RemoveListener(value);
    }

    public void UseInteractable(GameObject interactor)
    {
        _onInteract?.Invoke(interactor);

        Debug.Log("Interacted with : " + gameObject.name);
    }

    public void PickUpInteractable(GameObject interactor)
    {
        _onPickup?.Invoke(interactor);

        Debug.Log("Picked up : " + gameObject.name);
    }


}
