using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class RandomizePlayerOrder : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI roleText;
    [SerializeField] TextMeshProUGUI roleInstructionText;
    bool playerScreenVisibility = false;
    UDictionary<string, string> distributedRoles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        GameStateActions.OnDistributeRoles += GetDistributedRoles;
    }

    private void Update()
    {
        // If the player screen becomes visible again, we update the player that is shown.
        if(nameText.IsActive() && playerScreenVisibility != nameText.IsActive()) { DisplayNextPlayer(); }
        playerScreenVisibility = nameText.IsActive();
    }

    void GetDistributedRoles(UDictionary<string, string> roles)
    {
        distributedRoles = roles;
    }

    public void DisplayNextPlayer()
    {
        if(distributedRoles.Count > 0)
        {
            // Display text related to next player.
            int randomIndex = Random.Range(0, distributedRoles.Count);
            string playerName = distributedRoles.Keys[randomIndex];
            string playerRole = distributedRoles.Values[randomIndex];
            if (nameText != null) { nameText.text = playerName; }
            if (roleText != null && roleInstructionText != null) { CheckPlayerRole(playerRole); }
            Debug.LogFormat("Next player is {0} with role {1}", playerName, playerRole);

            distributedRoles.Remove(playerName);
            //Debug.Log("Roles left to distribute: " + distributedRoles.Count);
            GameStateActions.OnPlayerChanged?.Invoke(distributedRoles.Count);
            //GameStateActions
        }
    }

    void CheckPlayerRole(string role)
    {
        // TODO: Get instruction text from mystery randomizer.
        switch (role)
        {
            case "witness":
                roleText.text = "You are a witness";
                roleInstructionText.text = "You got woken up from your slumber due to some strange chewing and loud cracks coming from outside. But you were too tired to check it out and went back to sleep. The hint you got is [Time]";
                break;
            case "accomplice":
                roleText.text = "You are the accomplice";
                roleInstructionText.text = "The truth is: A group of beavers were illegally logging bird-inhabited trees early in the morning to build massive dams. Lie about the [Reason], [Species], or [Time] to make someone else look suspicious.";
                break;
        }
    }

    private void OnDestroy()
    {
        GameStateActions.OnDistributeRoles -= GetDistributedRoles;
    }
}
