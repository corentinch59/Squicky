using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    [SerializeField] private GameObject bubble;

    private float remaining = 0f;
    
    public void DisplayText(string t, float duration)
    {
        if (duration <= 0f) return;
        
        text.text = t;
        bubble.SetActive(true);
        remaining = duration;
    }

    public void Update()
    {
        remaining -= Time.deltaTime;
        
        if (remaining <= 0f)
        {
            text.text = string.Empty;
            bubble.SetActive(false);
        }
    }
}
