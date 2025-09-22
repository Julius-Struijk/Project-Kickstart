using UnityEngine;
using System.Collections.Generic;

public class FillNameText : MonoBehaviour
{
    List<string> playerNames;

    private void Awake()
    {
        GameStateActions.OnGivePlayerNames += GetPlayerNames;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerNames = new List<string>();
    }

    private void Update()
    {
        
    }

    void GetPlayerNames(List<string> pPlayerNames)
    {
        playerNames = pPlayerNames;
    }

    private void OnDestroy()
    {
        GameStateActions.OnGivePlayerNames -= GetPlayerNames;
    }
}
