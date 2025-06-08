using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentCordInteractable : MonoBehaviour
{
    [SerializeField] Material cutMaterial;
    public bool cut = false;
    public void Interact(GameObject interactor)
    {
        cut = true;
        GetComponent<MeshRenderer>().material = cutMaterial;
        GetComponentInParent<Tent>().UpdateCords();
    }
}
