using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BucketInteractable : MonoBehaviour, IInteractable, IDropable

{
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _jumpDuration;

    public void Interact(GameObject interactor)
    {
        PlayerInteraction p = interactor.GetComponent<PlayerInteraction>();
        if (p == null)
            return;

        Rigidbody rb = GetComponent<Rigidbody>();
        BoxCollider collider = GetComponent<BoxCollider>();
        if (rb != null)
        {
            rb.isKinematic = true;
            collider.enabled = false;
            rb.useGravity = false;
        }

        p.HeldInteractable = gameObject;
        transform.SetParent(interactor.transform);
        transform.DORotateQuaternion(Quaternion.identity, _jumpDuration);
        Tween t = transform.DOLocalJump(p.GetHeadSpot.localPosition, _jumpPower, 1, _jumpDuration);

    }

    public void Drop()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        BoxCollider collider = GetComponent<BoxCollider>();
        if (rb != null)
        {
            rb.isKinematic = false;
            collider.enabled = true;
            rb.useGravity = true;
        }
        transform.SetParent(null);
    }

    public void Use(GameObject interactor)
    {
        throw new System.NotImplementedException();
    }

}
