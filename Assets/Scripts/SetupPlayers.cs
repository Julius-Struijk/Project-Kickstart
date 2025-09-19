using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class SetupPlayers : MonoBehaviour
{
    Dictionary<string, GameObject> players;
    List<string> playerNames;
    List<GameObject> characters;

    private void Start()
    {
        players = new Dictionary<string, GameObject>();
        playerNames = new List<string>();
        characters = new List<GameObject>();
    }

    //Save player info once setup is complete.
    public void SavePlayerInfo()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform child = gameObject.transform.GetChild(i);
            for (int j = 0; j < child.childCount; j++)
            {
                // Check which player object it is and add it to the respective list.
                if (child.GetChild(j).gameObject.CompareTag("TextInput"))
                {
                    TMP_InputField textInput = child.GetChild(j).gameObject.GetComponent<TMP_InputField>();
                    if (textInput != null) { playerNames.Add(textInput.text); }
                }
                else if (child.GetChild(j).gameObject.CompareTag("PlayerImage"))
                {
                    characters.Add(child.GetChild(j).gameObject);
                }
            }

        }

        Debug.LogFormat("Names: {0} Characters: {1}", playerNames.Count, characters.Count);
        //Pair up gathered info into a dictionary.
        for (int i = 0; i < playerNames.Count; i++)
        {
            if(playerNames[i] != "")
            {
                Debug.LogFormat("Adding player {0} {1} with {2}", i + 1, playerNames[i], characters[i]);
                players.Add(playerNames[i], characters[i]);
            }
        }
    }
}
