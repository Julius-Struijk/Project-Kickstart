using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class FillNameText : MonoBehaviour
{
    List<string> playerNames;

    private void Awake()
    {
        GameStateActions.OnGivePlayerData += GetPlayerNames;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerNames = new List<string>();
        Debug.Log("Player names list initialized.");
        GameStateActions.OnRequestPlayerData?.Invoke();
    }

    void GetPlayerNames(Dictionary<string, GameObject> pPlayerData)
    {
        Debug.Log("Getting player names to fill text.");
        // Prevents adding the names twice if player data is requested by multiple scripts.
        if (pPlayerData != null && playerNames != null && playerNames.Count <= 0)
        {
            foreach (string name in pPlayerData.Keys)
            {
                playerNames.Add(name);
                Debug.LogFormat("Added name {0} to player names on {1} ", name, gameObject);
            }
            FillText();
        }
    }

    // Adds the player name to the text
    void FillText()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            TextMeshProUGUI playerName = gameObject.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
            if (playerName != null && i < playerNames.Count) { playerName.text = playerNames[i]; }
        }
    }

    //private void OnEnable()
    //{
    //    Debug.Log("Requesting player names in text filler " + gameObject);
    //    GameStateActions.OnRequestPlayerData?.Invoke();
    //}

    private void OnDestroy()
    {
        GameStateActions.OnGivePlayerData -= GetPlayerNames;
    }
}
