using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BubbleEventZone : MonoBehaviour
{
    public Journal journal;
    public JournalPage[] pagesToAdd;
    public Collider playerCollider;
    public string textToDisplay = "Texte";
    public float displayDuration = 5f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other == playerCollider)
        {
            foreach (JournalPage page in pagesToAdd)
            {
                journal.AddPage(page);
            }

            if (other.TryGetComponent<Bubble>(out var bubble))
            {
                bubble.DisplayText(textToDisplay, displayDuration);
            }
        }
    }
}
