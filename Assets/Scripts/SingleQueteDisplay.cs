using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SingleQueteDisplay : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public Quete quete;

    private void OnEnable()
    {
        quete.onQueteUpdated.AddListener(QueteUpdate);
        quete.onQueteCompleted.AddListener(QueteCompleted);
    }

    private void OnDisable()
    {
        quete.onQueteUpdated.RemoveListener(QueteUpdate);
        quete.onQueteCompleted.RemoveListener(QueteCompleted);
    }

    public void QueteUpdate()
    {
        titleText.text = quete.title;
        descriptionText.text = quete.description;
    }

    public void QueteCompleted(Quete q)
    {
        // strikethrough the text
        titleText.text = "<s>" + quete.title + "</s>";
        descriptionText.text = "<s>" + quete.description + "</s>";
    }
}
