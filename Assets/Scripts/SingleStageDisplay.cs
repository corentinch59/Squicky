using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SingleStageDisplay : MonoBehaviour
{
    [SerializeField]
    private TMP_Text title;
    [SerializeField]
    private TMP_Text description;

    public QueteStage quete
    {
        get => _quete;
        set
        {
            _quete = value;
            title.text = value.title + (value.IsCompleted() ? " (Done)" : "");
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
    
    private QueteStage _quete;
}
