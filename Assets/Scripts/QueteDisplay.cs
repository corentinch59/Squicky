using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueteDisplay : MonoBehaviour
{
    public Quete[] quetes;
    
    private void OnEnable()
    {
        
    }

    public void Toggle()
    {
        gameObject.SetActive(gameObject.activeSelf);
    }
}
