using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class TrashCanInteractable : MonoBehaviour, IInteractable
{
    private float _animationDuration = 0.5f;
    public UnityEvent onFinished;
    
    public GameObject UIPrefab;
    private GameObject _currentUI;
    
    public void Interact(GameObject interactor)
    {
        transform.DOShakeScale(_animationDuration);
        transform.DOShakeRotation(_animationDuration, new Vector3(0f, 30, 0f));
        transform.DOShakePosition(_animationDuration, new Vector3(0f, 0.3f, 0f), 10);
        
        interactor.GetComponent<Inventory>().ThrowTrash();
        onFinished.Invoke(); // callback quete qui progresse (dechets jetés)
    }
    
    private void ShowUI()
    {
        if (UIPrefab == null && _currentUI!=null) return;
        _currentUI = Instantiate(UIPrefab, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
    }

    private void HideUI()
    {
        if (_currentUI == null) return;
        Destroy(_currentUI);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        HideUI();
    }
    
}
