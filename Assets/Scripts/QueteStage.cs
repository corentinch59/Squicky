using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Quete Stage", menuName = "Squicky/Quete stage")]
public class QueteStage : ScriptableObject
{
    public string title;
    public string description;
    [SerializeField] private bool isCompleted;
    public UnityEvent<QueteStage> onCompleted;
    
    public void Complete()
    {
        if (isCompleted) return;
        isCompleted = true;
        onCompleted.Invoke(this);
        // avoid auto saving during play
#if UNITY_EDITOR
        EditorUtility.SetDirty(this);
#endif
    }
    
    public bool IsCompleted()
    {
        return isCompleted;
    }
}

// editor that adds a button to complete the quest
// #if UNITY_EDITOR
// [CustomEditor(typeof(QueteStage))]
// public class QueteStageEditor : Editor
// {
//     public override void OnInspectorGUI()
//     {
//         base.OnInspectorGUI();
//         
//         QueteStage queteStage = (QueteStage)target;
//         
//         if (GUILayout.Button("Complete Stage"))
//         {
//             queteStage.Complete();
//         }
//     }
// }
// #endif