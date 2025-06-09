using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanInteractable : MonoBehaviour, IInteractable
{
    public void Interact(GameObject interactor)
    {
        interactor.GetComponent<Inventory>().ThrowTrash();
    }
}
