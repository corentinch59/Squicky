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

    [SerializeField] public List<QueteStage> stages = new();

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

    public int GetStageCount()
    {
        return stages.Count;
    }
    
    public int GetCompletedStageCount()
    {
        int count = 0;
        foreach (QueteStage stage in stages)
        {
            if (stage.IsCompleted())
            {
                count++;
            }
        }
        return count;
    }

    public void FinishStage(int stage)
    {
        if (stage < 0 || stage >= stages.Count)
        {
            Debug.LogError("Invalid stage index: " + stage);
            return;
        }
        
        QueteStage queteStage = stages[stage];
        if (!queteStage.IsCompleted())
        {
            queteStage.Complete();
        }
        else
        {
            Debug.LogWarning("Stage " + stage + " is already completed.");
        }
    }
}
