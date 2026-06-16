using System;
using UnityEngine;

public class UIEvents : MonoBehaviour
{
    public static Action OnPlayerLivesChange;
    public static Action OnPlayerScoreChange;
    public static Action OnPlayerDead;
    
    public static void RaiseOnPlayerLivesChange() => OnPlayerLivesChange?.Invoke();
    public static void RaiseOnPlayerScoreChange() => OnPlayerScoreChange?.Invoke();
    public static void RaiseOnPlayerDead() => OnPlayerDead?.Invoke();
}
