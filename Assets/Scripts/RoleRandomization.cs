using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoleRandomization : MonoBehaviour
{
    [SerializeField] List<string> playerNames;
    [SerializeField] UDictionary<int, int> accompliceDistribution;
    List<string> rolesInPlay;
    UDictionary<string, string> distributedRoles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // TODO: Get player names.
        //playerNames = new List<string>();
        rolesInPlay = new List<string>();
        distributedRoles = new UDictionary<string, string>();
        Debug.LogFormat("Amount of players {0} Accomplice levels {1}", playerNames.Count, accompliceDistribution.Count);

        // Get number of accomplices
        int accompliceAmount = 0;
        for(int i = 0; i < accompliceDistribution.Count; i++)
        {
            if(playerNames.Count >= accompliceDistribution.Keys[i]) { accompliceAmount = accompliceDistribution.Values[i]; }
            else { break; }
        }
        Debug.Log("Amount of accomplices: " + accompliceAmount);

        // Add roles to role list.
        AddRoles(accompliceAmount, "accomplice");
        AddRoles(playerNames.Count - accompliceAmount, "witness");

        Debug.Log("Number of roles in play: " + rolesInPlay.Count);
        foreach(string role in rolesInPlay) { Debug.Log(role); }


        // Distribute roles to players
        foreach(string name in playerNames)
        {
            int randomIndex = Random.Range(0, rolesInPlay.Count);
            distributedRoles.Add(name, rolesInPlay[randomIndex]);
            Debug.LogFormat("Gave {0} role {1}", name, rolesInPlay[randomIndex]);
            rolesInPlay.RemoveAt(randomIndex);
        }

        // Send out distributed roles so turn order can be randomized.
        GameStateActions.OnDistributeRoles?.Invoke(distributedRoles);
    }

    void AddRoles(int roleAmount, string roleName)
    {
        for (int i = 0; i < roleAmount; i++) { rolesInPlay.Add(roleName); }
    }

}
