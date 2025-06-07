using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteract
{
    [SerializeField] string itemName;
    public void Interact(GameObject interactor)
    {
        interactor.GetComponent<Inventory>().GrabTrash();
        
        Destroy(gameObject);
    }
}
