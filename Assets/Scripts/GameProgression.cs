using UnityEngine;
using System.Collections.Generic;

public class GameProgression : MonoBehaviour
{
    [SerializeField] List<GameObject> screenDisplayOrder;
    int currentScreenIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(screenDisplayOrder.Count != 0) { screenDisplayOrder[currentScreenIndex].SetActive(true); }
    }

    public void ProgressGame()
    {
        screenDisplayOrder[currentScreenIndex].SetActive(false);
        // Loop progression back to start if we've reached the end of the game.
        if(currentScreenIndex + 1 >= screenDisplayOrder.Count) { currentScreenIndex = 0; }
        else { currentScreenIndex++; }
        screenDisplayOrder[currentScreenIndex].SetActive(true);
        Debug.Log("Moving to: " + screenDisplayOrder[currentScreenIndex].name);
    }
}