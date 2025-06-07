using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Quete", menuName = "Squicky/Quete")]
public class Quete : ScriptableObject
{
    public string title;
    public string description;
    public UnityEvent onQueteUpdated;
    public UnityEvent<Quete> onQueteCompleted;

    [SerializeField] private QueteStage[] stages;

    private void OnEnable()
    {
        foreach (QueteStage queteStage in stages)
        {
            queteStage.onCompleted.AddListener(OnStageCompleted);
        }
    }

    private void OnDisable()
    {
        foreach (QueteStage queteStage in stages)
        {
            queteStage.onCompleted.RemoveListener(OnStageCompleted);
        }
    }
    
    public bool IsCompleted()
    {
        foreach (QueteStage stage in stages)
        {
            if (!stage.IsCompleted())
            {
                return false;
            }
        }
        return true;
    }

    public void OnStageCompleted(QueteStage stage)
    {
        onQueteUpdated.Invoke();
        if (IsCompleted())
        {
            onQueteCompleted.Invoke(this);
        }
    }
}
