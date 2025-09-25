using UnityEngine;
using System.Collections.Generic;

public class ShowOnlyActiveBoxes : MonoBehaviour
{
    int playerAmount = 0;

    private void Awake()
    {
        GameStateActions.OnGivePlayerData += GetPlayerNames;
    }

    void GetPlayerNames(Dictionary<string, Sprite> pPlayerData)
    {
        Debug.Log("Getting player names to fill text.");
        // Prevents adding the names twice if player data is requested by multiple scripts.
        if (pPlayerData != null)
        {
            foreach (string name in pPlayerData.Keys) { playerAmount++; }
        }
        DisableUnusedBoxes();
    }

    void DisableUnusedBoxes()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform containerChild = gameObject.transform.GetChild(i);
            for (int j = 0; j < containerChild.childCount; j++)
            {
                if(j >= playerAmount)
                {
                    GameObject playerBox = containerChild.GetChild(j).gameObject;
                    playerBox.SetActive(false);
                }
            }
        }
    }

    private void OnDestroy()
    {
        GameStateActions.OnGivePlayerData -= GetPlayerNames;
    }
}
