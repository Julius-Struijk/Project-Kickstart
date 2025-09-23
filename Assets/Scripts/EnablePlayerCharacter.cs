using UnityEngine;
using System.Collections.Generic;

public class EnablePlayerCharacter : MonoBehaviour
{
    List<GameObject> playerCharacters;

    private void Awake()
    {
        GameStateActions.OnPlayerTurn += DisplaySpecificCharacter;
        GameStateActions.OnGivePlayerData += GetPlayerNames;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCharacters = new List<GameObject>();
        // Prevents requesting data multiple times if it has already been done by another script.
        if (playerCharacters.Count <= 0)
        {
            Debug.Log("Requesting player names in character enabler " + gameObject);
            GameStateActions.OnRequestPlayerData?.Invoke();
        }
    }

    void GetPlayerNames(Dictionary<string, GameObject> pPlayerData)
    {
        foreach(GameObject character in pPlayerData.Values)
        {
            playerCharacters.Add(character);
            Debug.Log("Added character: " + character);
        }
        //EnableCharacters();
    }

    void DisplayAllPlayerCharacters()
    {
        //for (int i = 0; i < gameObject.transform.childCount; i++)
        //{
        //    GameObject child = gameObject.transform.GetChild(i).gameObject;
        //    if (child == null) { playerName.text = playerNames[i]; }
        //}
    }

    void DisplaySpecificCharacter(string playerName)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject child = gameObject.transform.GetChild(i).gameObject;
            //if (child == playerCharacter) { child.SetActive(true); }
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
