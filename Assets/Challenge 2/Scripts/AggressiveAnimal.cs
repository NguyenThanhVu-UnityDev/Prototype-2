using UnityEngine;
using UnityEngine.UI;

public class AggressiveAnimal : MonoBehaviour
{
    [SerializeField] int requiredFoodCount = 3;
    [SerializeField] Slider hungerBar;

    private int currentFoodReceived = 0;

    private void Start()
    {
        UpdateHungerBar();
    }

    public void OnCollidedWithPlayer(GameObject player)
    {
        GameEvents.RaiseOnHitAnimal();
        gameObject.SetActive(false);
    }

    public void OnCollidedWithFood(GameObject food)
    {
        GameEvents.RaiseOnAnimalFed();
        food.gameObject.SetActive(false);
        currentFoodReceived++;
        UpdateHungerBar();
        if (currentFoodReceived >=  requiredFoodCount)
        {
             gameObject.SetActive(false);
        }
    }

    public void OnOutOfBound()
    {
        GameEvents.RainOnMissAnimal();
    }

    private void UpdateHungerBar()
    {
        if (hungerBar != null)
        {
            hungerBar.value = (float)currentFoodReceived / requiredFoodCount;
        }
    }
}
