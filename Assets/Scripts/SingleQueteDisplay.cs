using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SingleQueteDisplay : MonoBehaviour
{
    [SerializeField]
    private TMP_Text title;
    [SerializeField]
    private TMP_Text description;

    public Quete quete
    {
        get => _quete;
        set
        {
            _quete = value;
            title.text = value.title;
            description.text = value.description;
            
            if (value.IsCompleted())
            {
                title.color = Color.green;
            }
            else
            {
                title.color = Color.white;
            }
        }
    }
    
    public UnityEvent<Quete> onClick;
    private Quete _quete;

    public void InvokeOnClick()
    {
        if (onClick != null)
        {
            onClick.Invoke(quete);
        }
    }
}
