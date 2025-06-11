using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WasteInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] string itemName;
    
    private float _animationDuration = 0.3f;
    private bool _hasBeenCollected = false;
    
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
            interactor.GetComponent<Inventory>().GrabTrash();
            Destroy(gameObject);
        }));

        


    }

}
