using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalDisplay : MonoBehaviour
{
    [SerializeField]
    private Journal journal;

    [SerializeField] private Image leftPage;
    [SerializeField] private Image rightPage;
    
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;

    private int currentIndex = 0;

    private void OnEnable()
    {
        OnJournalUpdated();
    }

    public void NextPage()
    {
        currentIndex = Mathf.Min(currentIndex + 2, journal.GetPageCount());
        currentIndex -= currentIndex % 2;
        OnJournalUpdated();
    }

    public void PreviousPage()
    {
        currentIndex = Mathf.Max(0, currentIndex - 2);
        OnJournalUpdated();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        journal.onJournalUpdated.AddListener(OnJournalUpdated);
    }
    
    void OnDestroy()
    {
        journal.onJournalUpdated.RemoveListener(OnJournalUpdated);
    }

    public void OnJournalUpdated()
    {
        JournalPage leftPageData = journal.GetPage(currentIndex);
        JournalPage rightPageData = journal.GetPage(currentIndex + 1);
        if (leftPageData != null)
        {
            leftPage.sprite = leftPageData.pageImage;
            leftPage.gameObject.SetActive(true);
        }
        else
        {
            leftPage.gameObject.SetActive(false);
        }
        
        if (rightPageData != null)
        {
            rightPage.sprite = rightPageData.pageImage;
            rightPage.gameObject.SetActive(true);
        }
        else
        {
            rightPage.gameObject.SetActive(false);
        }
        
        // hide or show buttons
        nextButton.gameObject.SetActive(currentIndex < journal.GetPageCount() - journal.GetPageCount() % 2);
        previousButton.gameObject.SetActive(currentIndex > 0);
    }

    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
