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
        GameStateActions.OnGameProgress += SwitchScreens;
        if(screenDisplayOrder.Count != 0) { screenDisplayOrder[currentScreenIndex].SetActive(true); }
    }

    public void SwitchScreens()
    {
        screenDisplayOrder[currentScreenIndex].SetActive(false);
        // Loop progression back to start if we've reached the end of the game.
        if(currentScreenIndex + 1 >= screenDisplayOrder.Count) { currentScreenIndex = 0; }
        else { currentScreenIndex++; }
        screenDisplayOrder[currentScreenIndex].SetActive(true);
        Debug.Log("Moving to: " + screenDisplayOrder[currentScreenIndex].name);
    }

    private void OnDisable()
    {
        GameStateActions.OnGameProgress -= SwitchScreens;
    }
}