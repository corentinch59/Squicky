using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCords()
    {
        TentCordInteractable[] cords = GetComponentsInChildren<TentCordInteractable>();
        foreach (var cord in cords)
        {
            if (!cord.cut)
            {
                return;
            }
        }
        Destroy(gameObject);
    }
}
