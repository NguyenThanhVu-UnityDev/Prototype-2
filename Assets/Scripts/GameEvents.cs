using System;
using UnityEngine;

public static class GameEvents
{
    public static Action OnAnimalFed;
    public static Action OnHitAnimal;
    public static Action OnMissAnimal;

    public static void RaiseOnAnimalFed() => OnAnimalFed?.Invoke();
    public static void RaiseOnHitAnimal() => OnHitAnimal?.Invoke();
    public static void RainOnMissAnimal() => OnMissAnimal?.Invoke();
}
