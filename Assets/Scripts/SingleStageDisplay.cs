using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class SingleStageDisplay : MonoBehaviour
{
    [SerializeField]
    private TMP_Text title;
    [SerializeField]
    private TMP_Text description;
    [SerializeField] public Compass compass;

    public QueteStage quete
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

    public void Suivre()
    {
        compass.target = null;
        // find all references of QueteStage in the scene
        foreach (var go in FindAllGameObjectsThatDirectlyReference(_quete))
        {
            if (go == gameObject) continue; 
            
            Debug.Log(go.name);
            if (compass != null)
            {
                compass.target = go;
            }

            break;
        }
    }
    
    public static IEnumerable<GameObject> FindAllGameObjectsThatDirectlyReference(ScriptableObject target)
    {
        HashSet<GameObject> results = new HashSet<GameObject>();

        foreach(var componentType in TypeCache.GetTypesDerivedFrom<MonoBehaviour>())
        {
            if(componentType.IsGenericTypeDefinition)
            {
                continue;
            }

            Object[] instancesOfType = null;
            const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            foreach(var field in componentType.GetFields(flags))
            {
                if(field.FieldType.IsInstanceOfType(target))
                {
                    instancesOfType ??= FindObjectsOfType(componentType, true);

                    foreach(var instance in instancesOfType)
                    {
                        if(field.GetValue(instance) as Object == target)
                        {
                            results.Add((instance as Component).gameObject);
                        }
                    }
                    // if is derived of UnityEventBase
                } else if (field.FieldType.IsSubclassOf(typeof(UnityEventBase)))
                {
                    instancesOfType ??= FindObjectsOfType(componentType, true);

                    foreach(var instance in instancesOfType)
                    {
                        var unityEvent = field.GetValue(instance) as UnityEventBase;
                        if (unityEvent != null && unityEvent.GetPersistentEventCount() > 0)
                        {
                            for (int i = 0; i < unityEvent.GetPersistentEventCount(); i++)
                            {
                                if (unityEvent.GetPersistentTarget(i) == target)
                                {
                                    results.Add((instance as Component).gameObject);
                                }
                            }
                        }
                    }
                }
            }
        }

        return results;
    }
    
    private QueteStage _quete;
}
