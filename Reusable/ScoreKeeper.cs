using UnityEngine;
using TMPro;  // Make sure to include this namespace for TextMeshProUGUI

public class ScoreKeeper : MonoBehaviour
{
    private static int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        UpdateScoreUI();
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int s)
    {
        score = s;
        UpdateScoreUI();
    }

    public void IncrementScore(int i)
    {
        score += i;
        UpdateScoreUI();
    }

    public void DecrementScore(int i)
    {
        score -= i;
        CheckScore();
        UpdateScoreUI();
    }

    private void CheckScore()
    {
        if (score < -99)
        {
            score = 0;
            SceneLoader sceneLoader = FindObjectOfType<SceneLoader>();
            if (sceneLoader != null)
            {
                sceneLoader.LoadSceneWithDelay("GameOver", 0.5f);
            }
            Destroy(gameObject);
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
