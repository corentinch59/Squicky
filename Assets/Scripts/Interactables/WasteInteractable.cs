using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] string itemName;
    public void Interact(GameObject interactor)
    {
        interactor.GetComponent<Inventory>().GrabTrash();
        
        Destroy(gameObject);
    }
}
