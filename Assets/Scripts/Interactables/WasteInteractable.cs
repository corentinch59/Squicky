using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class WasteInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] string itemName;
    
    private float _animationDuration = 0.3f;
    private bool _hasBeenCollected = false;
    public UnityEvent onFinished;
    public GameObject UIPrefab;
    private GameObject _currentUI;
    
    public void Interact(GameObject interactor)
    {
        if (_hasBeenCollected) return;
        _hasBeenCollected = true;
        
        // animation collecte déchet
        Sequence seq = DOTween.Sequence();
        seq.Join(transform.DOShakeRotation(_animationDuration, new Vector3(0,20,0), 5, 5, true));
        seq.Join(transform.DOJump(transform.position+ new Vector3(0, 1.5f, 0), 0.5f, 1, _animationDuration));
        seq.Append(transform.DOScale(0, _animationDuration/3));
        seq.AppendCallback((() =>
        {
            onFinished.Invoke(); // callback dechet ramassé
            Destroy(_currentUI);
            Destroy(gameObject);
        }));

        


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
