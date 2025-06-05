using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Journal", menuName = "Squicky/Journal")]
public class Journal : ScriptableObject
{
    [SerializeField] private JournalPage[] pages;
    public UnityEvent onJournalUpdated;

    public void AddPage(JournalPage page)
    {
        // if page with the same number already exists, remove the previous one
        pages = pages.Where(p => p.pageNumber != page.pageNumber).ToArray();
        
        pages.Append(page);
        pages = pages.OrderBy(p => p.pageNumber).ToArray();
        onJournalUpdated.Invoke();
    }

    public int GetPageCount()
    {
        return pages.Aggregate(0, (count, page) => Mathf.Max(count, page.pageNumber));
    }
    
    public JournalPage GetPage(int pageNumber)
    {
        return pages.FirstOrDefault(page => page.pageNumber == pageNumber);
    }
}