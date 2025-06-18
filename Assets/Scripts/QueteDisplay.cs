using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueteDisplay : MonoBehaviour
{
    public Quete[] quetes;
    public GameObject singleQuetePrefab;
    public GameObject singleStagePrefab;
    public GameObject content;
    public GameObject stageContent;
    public Compass compass;
    
    private void OnEnable()
    {
        // remove all children from content
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }
        
        // remove all children from stageContent
        foreach (Transform child in stageContent.transform)
        {
            Destroy(child.gameObject);
        }
        
        // instantiate a new singleQuetePrefab for each quete
        foreach (Quete quete in quetes)
        {
            GameObject singleQuete = Instantiate(singleQuetePrefab, content.transform);
            SingleQueteDisplay singleQueteDisplay = singleQuete.GetComponent<SingleQueteDisplay>();
            if (singleQueteDisplay != null)
            {
                singleQueteDisplay.quete = quete;
                singleQueteDisplay.onClick.AddListener(DisplayQuete);
            }
        }
    }

    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    public void DisplayQuete(Quete quete)
    {
        // remove all children from stageContent
        foreach (Transform child in stageContent.transform)
        {
            Destroy(child.gameObject);
        }
        
        // instantiate a new SingleStageDisplay for each stage in the quete
        foreach (QueteStage stage in quete.stages)
        {
            GameObject singleStage = Instantiate(singleStagePrefab, stageContent.transform);
            SingleStageDisplay singleStageDisplay = singleStage.GetComponent<SingleStageDisplay>();
            singleStageDisplay.compass = compass;
            if (singleStageDisplay != null)
            {
                singleStageDisplay.quete = stage;
            }
        }
    }
}
