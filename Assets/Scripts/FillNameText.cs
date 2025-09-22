using UnityEngine;
using System.Collections.Generic;

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
        Debug.Log("Starting text filler in " + gameObject);
        playerNames = new List<string>();
        GameStateActions.OnRequestPlayerData?.Invoke();
    }

    private void Update()
    {
        
    }

    void GetPlayerNames(Dictionary<string, GameObject> pPlayerData)
    {
        foreach(string name in pPlayerData.Keys)
        {
            playerNames.Add(name);
            //Debug.Log("Added name: " + name);
        }
    }

    // Adds the player name to the text
    void AddName()
    {

    }

    private void OnDestroy()
    {
        GameStateActions.OnGivePlayerData -= GetPlayerNames;
    }
}
