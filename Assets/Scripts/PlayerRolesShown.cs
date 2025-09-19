using UnityEngine;

public class PlayerRolesShown : MonoBehaviour
{
    int unshownPlayers;

    private void Awake()
    {
        GameStateActions.OnPlayerChanged += UpdateUnshownPlayers;
    }

    // Checks if all players have been shown yet to decide where the game will progress.
    public void CheckUnshownPlayers()
    {
        Debug.Log("Unshown players: " + unshownPlayers);
        // If all players haven't been shown yet, we return to the player role screen. Otherwise we continue.
        if(unshownPlayers != 0) { GameStateActions.OnGameProgress?.Invoke(-1); }
        else { GameStateActions.OnGameProgress?.Invoke(1); }
    }

    void UpdateUnshownPlayers(int players)
    {
        Debug.Log("Setting unshown players to: " + players);
        unshownPlayers = players;
    }

    private void OnDestroy()
    {
        GameStateActions.OnPlayerChanged -= UpdateUnshownPlayers;
    }
}
