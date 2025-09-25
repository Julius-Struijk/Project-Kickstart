using UnityEngine;
using System.Collections.Generic;

public class RulesPage : MonoBehaviour
{
    public GameObject[] pages;
    private int currentIndex = 0;
    private List<int> previousIndex = new List<int>();

    private void Awake()
    {
        GameStateActions.OnScreenSkip += AdvancePage;
        GameStateActions.OnGameReverse += pageBack;
    }

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

    // This is so that the correct index can be set once all the player roles have been gone through.
    void AdvancePage()
    {
        ShowPage(currentIndex + 1);
    }

    public void pageBack()
    {
        pages[currentIndex].SetActive(false);
        pages[previousIndex[previousIndex.Count-1]].SetActive(true);
        currentIndex = previousIndex[previousIndex.Count - 1];
        previousIndex.RemoveAt(previousIndex.Count - 1);
    }

    private void OnDestroy()
    {
        GameStateActions.OnScreenSkip -= AdvancePage;
        GameStateActions.OnGameReverse -= pageBack;
    }
}

