using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TrashCanInteractable : MonoBehaviour, IInteractable
{
    private float _animationDuration = 0.5f;
    public void Interact(GameObject interactor)
    {
        transform.DOShakeScale(_animationDuration);
        transform.DOShakeRotation(_animationDuration, new Vector3(0f, 30, 0f));
        transform.DOShakePosition(_animationDuration, new Vector3(0f, 0.3f, 0f), 10);
        
        interactor.GetComponent<Inventory>().ThrowTrash();
    }
}
