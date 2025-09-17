using UnityEngine;
using System.Collections.Generic;

public class GameProgression : MonoBehaviour
{
    // TODO: Get number of players.
    [SerializeField] List<GameObject> screenDisplayOrder;
    int currentScreenIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Deactivate all screens before game start
        foreach(GameObject screen in screenDisplayOrder)
        {
            screen.SetActive(false);
        }

        GameStateActions.OnGameProgress += SwitchScreens;
        if(screenDisplayOrder.Count != 0) { screenDisplayOrder[currentScreenIndex].SetActive(true); }
    }

    // TODO: If value is passed, switch to the screen that corresponds to the index.
    public void SwitchScreens(int switchAmount = 1)
    {
        screenDisplayOrder[currentScreenIndex].SetActive(false);
        // Failsafes incase invalid values are inputted.
        if(currentScreenIndex + switchAmount >= screenDisplayOrder.Count) { currentScreenIndex = 0; }
        else if( currentScreenIndex + switchAmount < 0) { currentScreenIndex++; }
        else { currentScreenIndex += switchAmount; }
        screenDisplayOrder[currentScreenIndex].SetActive(true);
        Debug.Log("Moving to: " + screenDisplayOrder[currentScreenIndex].name);
    }

    private void OnDisable()
    {
        GameStateActions.OnGameProgress -= SwitchScreens;
    }
}