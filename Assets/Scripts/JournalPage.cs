using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Journal Page", menuName = "Squicky/Page")]
public class JournalPage : ScriptableObject
{
    public Sprite pageImage;
    public int pageNumber;
}
