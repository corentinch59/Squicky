using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueteDisplay : MonoBehaviour
{
    public Quete[] quetes;
    [SerializeField]
    private GameObject singleQuetePrefab;
    
    private void OnEnable()
    {
        foreach (Quete quete in quetes)
        {
            GameObject queteDisplay = Instantiate(singleQuetePrefab, transform);
            SingleQueteDisplay singleQueteDisplay = queteDisplay.GetComponent<SingleQueteDisplay>();
            singleQueteDisplay.quete = quete;
            singleQueteDisplay.QueteUpdate();
        }
    }
}
