using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void Start()
    {
        OnPlayerLivesChange();
        OnPlayerScoreChange();
    }

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

    public void OnPlayerLivesChange()
    {
        if (GameManager.Instance != null)
        {
            Debug.Log("Lives = " + GameManager.Instance.Lives);
        }
    }

    public void OnPlayerScoreChange()
    {
        if (GameManager.Instance != null)
        {
            Debug.Log("Score = " + GameManager.Instance.Score);
        }
    }

    public void OnPlayerDead()
    {
        Debug.Log("Game Over");
    }
}
