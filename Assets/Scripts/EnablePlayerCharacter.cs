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

    void GetPlayerNames(Dictionary<string, Sprite> pPlayerData)
    {
        if (players.Count <= 0)
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
        Debug.LogFormat("Checking if {0}'s character can be displayed in {1}", playerName, gameObject.transform.parent.gameObject);

        if (players == null)
        {
            players = new Dictionary<string, Sprite>();
            Debug.LogFormat("Requesting player names in character enabler in {0} with player count {1}", gameObject.transform.parent.gameObject, players.Count);
            GameStateActions.OnRequestPlayerData?.Invoke();
        }

        if (players != null)
        {
            players.TryGetValue(playerName, out Sprite character);
            if (character != null)
            {
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    SpriteRenderer child = gameObject.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();

                    //Debug.LogFormat("Checking if player character {0} is the same as character {1}.", character, child.sprite);
                    if (child.sprite == character)
                    {
                        Debug.Log("Showing specific player character " + character.name);
                        child.gameObject.SetActive(true);
                    }
                    else { child.gameObject.SetActive(false); }
                }
            }
        }
    }

    private void OnEnable()
    {
        //if(players != null)
        //{
        //    if(characterDisplayAmount == 1) {  }
        //}
    }

    private void OnDestroy()
    {
        GameStateActions.OnPlayerTurn -= DisplaySpecificCharacter;
        GameStateActions.OnGivePlayerData -= GetPlayerNames;
    }
}
