using UnityEngine;

public class RulesPages : MonoBehaviour
{
    public GameObject[] pages; 
    private int currentIndex = 0;
    private int previousIndex = 0;

    public void ShowPage(int pageNumbers)
    {
        pages[currentIndex].SetActive(false);
        pages[pageNumbers].SetActive(true);
        previousIndex = currentIndex;
        currentIndex = pageNumbers;
    }

    public void pageBack()
    {
        pages[currentIndex].SetActive(false);
        pages[previousIndex].SetActive(true);
        int tempIndex = previousIndex;
        previousIndex = currentIndex;
        currentIndex = tempIndex;
    }
}