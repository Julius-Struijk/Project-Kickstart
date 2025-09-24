using UnityEngine;
using System.Collections.Generic;

public class EnablePlayerCharacter : MonoBehaviour
{
    Dictionary<string, Sprite> players;

    private void Awake()
    {
        GameStateActions.OnPlayerTurn += DisplaySpecificCharacter;
        GameStateActions.OnGivePlayerData += GetPlayerNames;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        players = new Dictionary<string, Sprite>();
        // Prevents requesting data multiple times if it has already been done by another script.
        if (players.Count <= 0)
        {
            Debug.LogFormat("Requesting player names in character enabler {0} with player count {1}", gameObject, players.Count);
            GameStateActions.OnRequestPlayerData?.Invoke();
        }
    }

    void GetPlayerNames(Dictionary<string, Sprite> pPlayerData)
    {
        if(players.Count <= 0)
        {
            foreach (KeyValuePair<string, Sprite> player in pPlayerData)
            {
                players.Add(player.Key, player.Value);
                Debug.Log("Added character: " + player.Value);
            }
            //EnableCharacters();
        }
    }

    void DisplayAllPlayerCharacters()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            SpriteRenderer child = gameObject.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            if (players.ContainsValue(child.sprite)) { child.gameObject.SetActive(true); }
        }
    }

    void DisplaySpecificCharacter(string playerName)
    {
        if(players != null)
        {
            Debug.LogFormat("Checking if {0}'s character can be displayed.", playerName);
            players.TryGetValue(playerName, out Sprite character);
            if(character != null)
            {
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    SpriteRenderer child = gameObject.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();

                    Debug.LogFormat("Checking if player character {0} is the same as character {1}.", character, child.sprite);
                    if (child.sprite == character)
                    {
                        Debug.Log("Showing specific player character " + character.name);
                        child.gameObject.SetActive(true);
                        break;
                    }
                }
            }
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
