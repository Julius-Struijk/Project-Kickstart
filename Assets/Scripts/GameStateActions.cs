using UnityEngine;
using System;
using System.Collections.Generic;

public static class GameStateActions
{
    public static Action<int> OnGameProgress;

    public static Action<UDictionary<string, string>> OnDistributeRoles;

    public static Action<int> OnPlayerChanged;

    public static Action<Dictionary<string, Sprite>> OnGivePlayerData;

    public static Action OnRequestPlayerData;

    public static Action<String> OnPlayerTurn;

    public static Action<Dictionary<string, string>> OnCrimesSaved;
}
