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
    }

    void GetPlayerNames(Dictionary<string, GameObject> pPlayerData)
    {
        foreach(string name in pPlayerData.Keys)
        {
            playerNames.Add(name);
            //Debug.Log("Added name: " + name);
        }
        FillText();
    }

    // Adds the player name to the text
    void FillText()
    {
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            TextMeshProUGUI playerName = gameObject.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
            if(playerName != null) { playerName.text = playerNames[i]; }
        }
    }

    private void OnEnable()
    {
        //Debug.Log("Requesting player names in text filler " + gameObject);
        GameStateActions.OnRequestPlayerData?.Invoke();
    }

    private void OnDestroy()
    {
        GameStateActions.OnGivePlayerData -= GetPlayerNames;
    }
}
