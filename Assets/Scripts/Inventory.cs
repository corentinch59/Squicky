using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    private int trashCounter = 0;
    public TMP_Text trashCounterText;

    private void Start()
    {
        trashCounterText.text = trashCounter.ToString();
    }

    public void GrabTrash()
    {
        trashCounter += 1;
        
        trashCounterText.text = trashCounter.ToString();

        
    }
}


