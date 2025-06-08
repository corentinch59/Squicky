using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteract 
{
    public void UseInteractable(GameObject interactor);
    public void PickUpInteractable(GameObject interactor);
}
