using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class CollectCrimes : MonoBehaviour
{
    Dictionary<string, string> playerCrimes;
    List<string> playerNames;
    List<string> inputCrimes;




    private void Start()
    {
        playerCrimes = new Dictionary<string, string>();
        playerNames = new List<string>();
        inputCrimes = new List<string>();
    }


    public void SaveCrimeGuesses()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform child = gameObject.transform.GetChild(i);
            for (int j = 0; j < child.childCount; j++)
            {
                // Check which player object it is and add it to the respective list.
                GameObject textChild = child.GetChild(j).gameObject;
                if (textChild.CompareTag("TextInput"))
                {
                    TMP_InputField textInput = textChild.GetComponent<TMP_InputField>();
                    //Debug.Log("Adding crime: " + textInput.text);
                    if (textInput != null) { inputCrimes.Add(textInput.text); }
                }
                else if(textChild.CompareTag("Player"))
                {
                    TMP_Text textInput = textChild.GetComponent<TMP_Text>();
                    //Debug.Log("Adding character: " + textInput.text);
                    if (textInput != null) { playerNames.Add(textInput.text); }
                }
            }

        }

        //Debug.LogFormat("Names: {0} Crimes: {1}", playerNames.Count, inputCrimes.Count);
        //Pair up gathered info into a dictionary.
        for (int i = 0; i < playerNames.Count; i++)
        {
            if (playerNames[i] != "")
            {
                Debug.LogFormat("Adding player {0} {1} with {2}", i + 1, playerNames[i], inputCrimes[i]);
                playerCrimes.Add(playerNames[i], inputCrimes[i]);
            }
        }
        GameStateActions.OnCrimesSaved?.Invoke(playerCrimes);
    }
}
