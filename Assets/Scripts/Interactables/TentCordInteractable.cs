using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentCordInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] Material cutMaterial;
    public bool cut = false;
    
    public GameObject UIPrefab;
    private GameObject _currentUI;
    
    public void Interact(GameObject interactor)
    {
        cut = true;
        GetComponent<MeshRenderer>().material = cutMaterial;
        GetComponentInParent<Tent>().UpdateCords();
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
