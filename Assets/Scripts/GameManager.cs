using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; }

    [SerializeField] int lives = 3;
    [SerializeField] int score = 0;

    [SerializeField] int animalFedPoint = 1;
    [SerializeField] int animalMissOrHitPenalty = 1;

    public int Lives { get => lives; }
    public int Score { get => score; }

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(instance);
        instance = this;
    }

    private void OnEnable()
    {
        GameEvents.OnAnimalFed += OnAnimalFed;
        GameEvents.OnMissAnimal += OnAnimalMissOrHit;
        GameEvents.OnHitAnimal += OnAnimalMissOrHit;
    }

    private void OnDisable()
    {
        GameEvents.OnAnimalFed -= OnAnimalFed;
        GameEvents.OnMissAnimal -= OnAnimalMissOrHit;
        GameEvents.OnHitAnimal -= OnAnimalMissOrHit;
    }

    private void Start()
    {
        UIEvents.RaiseOnPlayerLivesChange(lives);
        UIEvents.RaiseOnPlayerScoreChange(score);
    }

    public void DecreaseLives(int increment = 1)
    {
        lives -= increment;
        if (lives < 0)
        {
            lives = 0;
            UIEvents.RaiseOnPlayerDead();
        }
        UIEvents.RaiseOnPlayerLivesChange(lives);
    }

    public void AddScore(int points)
    {
        score += points;
        UIEvents.RaiseOnPlayerScoreChange(score);
    }

    public void OnAnimalFed()
    {
        Debug.Log("An aniamal is fed!");
        AddScore(animalFedPoint);
    }

    public void OnAnimalMissOrHit()
    {
        Debug.Log("Miss an animal!");
        DecreaseLives(animalMissOrHitPenalty);
    }
}
