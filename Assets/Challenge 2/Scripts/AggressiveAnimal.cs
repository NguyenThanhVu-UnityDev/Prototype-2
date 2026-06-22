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
        Destroy(gameObject);
    }

    public void OnCollidedWithFood(GameObject food)
    {
        GameEvents.RaiseOnAnimalFed();
        Destroy(food.gameObject);
        //Destroy(gameObject);
        currentFoodReceived++;
        UpdateHungerBar();
        if (currentFoodReceived >=  requiredFoodCount)
        {
            Destroy(gameObject);
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
