using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BucketInteractable : MonoBehaviour, IInteractable, IDropable

{
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _jumpDuration;
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private GameObject emptyBucketModel;
    [SerializeField] private GameObject fullBucketModel;

    [HideInInspector] public bool isBucketFilled = false;

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
        transform.DORotateQuaternion(interactor.transform.rotation, _jumpDuration);
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
        Collider[] hits = Physics.OverlapSphere(transform.position, 4, _layerMask);

        if (hits.Length <= 0)
            return;

        float d = (hits[0].transform.position - transform.position).sqrMagnitude;
        GameObject temp = hits[0].gameObject;

        foreach (var hit in hits)
        {
            float tempD = (hit.transform.position - transform.position).sqrMagnitude;
            if (tempD < d)
            {
                d = tempD;
                temp = hit.gameObject;
            }
        }


        if (temp != null)
        {
            IBucketReceiver interactable = temp.GetComponent<IBucketReceiver>();
            if (interactable == null)
                return;

            interactable.ReceiveBucket(this);
        }
    }

    public void Update()
    {
        emptyBucketModel.SetActive(!isBucketFilled);
        fullBucketModel.SetActive(isBucketFilled);
    }
}