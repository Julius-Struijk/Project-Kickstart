using UnityEngine;
using System.Collections.Generic;

public class EnablePlayerCharacter : MonoBehaviour
{
    Dictionary<string, GameObject> players;

    private void Awake()
    {
        GameStateActions.OnPlayerTurn += DisplaySpecificCharacter;
        GameStateActions.OnGivePlayerData += GetPlayerNames;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        players = new Dictionary<string, GameObject>();
        // Prevents requesting data multiple times if it has already been done by another script.
        if (players.Count <= 0)
        {
            Debug.Log("Requesting player names in character enabler " + gameObject);
            GameStateActions.OnRequestPlayerData?.Invoke();
        }
    }

    void GetPlayerNames(Dictionary<string, GameObject> pPlayerData)
    {
        foreach(KeyValuePair<string, GameObject> player in pPlayerData)
        {
            players.Add(player.Key, player.Value);
            Debug.Log("Added character: " + player.Value);
        }
        //EnableCharacters();
    }

    void DisplayAllPlayerCharacters()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject child = gameObject.transform.GetChild(i).gameObject;
            if (players.ContainsValue(child)) { child.SetActive(true); }
        }
    }

    void DisplaySpecificCharacter(string playerName)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject child = gameObject.transform.GetChild(i).gameObject;
            players.TryGetValue(playerName, out GameObject character);
            if (character != null && child == character) 
            {
                Debug.Log("Showing specific player character " + character);
                child.SetActive(true); 
            }
            break;
        }
    }

    private void OnEnable()
    {
        //// Prevents requesting data multiple times if it has already been done by another script.
        //if (playerCharacters.Count <= 0)
        //{
        //    Debug.Log("Requesting player names in character enabler " + gameObject);
        //    GameStateActions.OnRequestPlayerData?.Invoke();
        //}
    }

    private void OnDestroy()
    {
        GameStateActions.OnPlayerTurn -= DisplaySpecificCharacter;
        GameStateActions.OnGivePlayerData -= GetPlayerNames;
    }
}
