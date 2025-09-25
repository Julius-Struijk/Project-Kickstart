using UnityEngine;
using System.Collections.Generic;

public class RulesPage : MonoBehaviour
{
    public GameObject[] pages;
    private int currentIndex = 0;
    private List<int> previousIndex = new List<int>();

    private void Start()
    {
        pages[0].SetActive(true);
    }

    public void ShowPage(int pageNumbers)
    {
        pages[currentIndex].SetActive(false);
        pages[pageNumbers].SetActive(true);
        if(pageNumbers == 0 ) { previousIndex.Clear(); }
        previousIndex.Add(currentIndex);
        currentIndex = pageNumbers;
    }

    public void pageBack()
    {
        pages[currentIndex].SetActive(false);
        pages[previousIndex[previousIndex.Count-1]].SetActive(true);
        currentIndex = previousIndex[previousIndex.Count - 1];
        previousIndex.RemoveAt(previousIndex.Count - 1);
    }
}

