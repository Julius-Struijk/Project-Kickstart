using UnityEngine;
using System;
using System.Collections.Generic;

public static class GameStateActions
{
    public static Action<int> OnGameProgress;

    public static Action<UDictionary<string, string>> OnDistributeRoles;

    public static Action<int> OnPlayerChanged;
}
