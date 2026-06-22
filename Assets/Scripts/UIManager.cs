using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void OnEnable()
    {
        UIEvents.OnPlayerLivesChange += OnPlayerLivesChange;
        UIEvents.OnPlayerScoreChange += OnPlayerScoreChange;
        UIEvents.OnPlayerDead += OnPlayerDead;
    }

    private void OnDisable()
    {
        UIEvents.OnPlayerLivesChange -= OnPlayerLivesChange;
        UIEvents.OnPlayerScoreChange -= OnPlayerScoreChange;
        UIEvents.OnPlayerDead -= OnPlayerDead;
    }

    public void OnPlayerLivesChange(int newLive)
    {
        if (GameManager.Instance != null)
        {
            Debug.Log("Lives = " + newLive);
        }
    }

    public void OnPlayerScoreChange(int newScore)
    {
        if (GameManager.Instance != null)
        {
            Debug.Log("Score = " + newScore);
        }
    }

    public void OnPlayerDead()
    {
        Debug.Log("Game Over");
    }
}
