using UnityEngine;

public class TipsScript : MonoBehaviour
{
    private ScoreKeeper scoreKeeper;
    
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        if (scoreKeeper == null)
        {
            Debug.Log("ScoreKeeper instance not found");
        }
    }

    public void ReduceScore()
    {
        if (scoreKeeper != null)
        {
            scoreKeeper.DecrementScore(5);
        }
        else
        {
            Debug.Log("ScoreKeeper instance is not initialized");
        }
    }
}
