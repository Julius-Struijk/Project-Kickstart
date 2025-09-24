using UnityEngine;
using System.Collections.Generic;

public class ShowOnlyActiveBoxes : MonoBehaviour
{
    int playerAmount = 0;

    private void Awake()
    {
        GameStateActions.OnGivePlayerData += GetPlayerNames;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //// Find the game object that has the player names.
        //for (int i = 0; i < gameObject.transform.childCount; i++)
        //{
        //    GameObject containerChild = gameObject.transform.GetChild(i).gameObject;
        //    if (containerChild.GetComponent<FillNameText>())
        //    {
        //        for (int j = 0; j < containerChild.transform.childCount; j++)
        //        {
        //            transform child = containerChild.transform.GetChild(i);
        //            if (child.GetChild(j).gameObject.CompareTag("TextInput"))
        //            {
        //                TMP_InputField textInput = child.GetChild(j).gameObject.GetComponent<TMP_InputField>();
        //                if (textInput != null) { playerNames.Add(textInput.text); }
        //            }
        //        }
        //    }
        //}
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
