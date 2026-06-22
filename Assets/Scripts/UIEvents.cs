using System;
using UnityEngine;

public class UIEvents : MonoBehaviour
{
    public static Action<int> OnPlayerLivesChange;
    public static Action<int> OnPlayerScoreChange;
    public static Action OnPlayerDead;
    
    public static void RaiseOnPlayerLivesChange(int newLive) => OnPlayerLivesChange?.Invoke(newLive);
    public static void RaiseOnPlayerScoreChange(int newScore) => OnPlayerScoreChange?.Invoke(newScore);
    public static void RaiseOnPlayerDead() => OnPlayerDead?.Invoke();
}
