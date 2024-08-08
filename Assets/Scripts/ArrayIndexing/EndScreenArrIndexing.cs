using TMPro;
using UnityEngine;

public class EndScreenArrIndexing : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] GameObject[] elementsToDisable; // Add references to all elements to disable
    ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        TimerForIndexingLevel.TimerEnded += OnTimerEnded; // Subscribe to the TimerEnded event
        gameObject.SetActive(false); // Initially hide the end screen
    }

    void OnDestroy()
    {
        TimerForIndexingLevel.TimerEnded -= OnTimerEnded; // Unsubscribe from the TimerEnded event
    }

    private void OnTimerEnded()
    {
        ShowFinalScore();
        DisableOtherElements();
    }

    public void ShowFinalScore()
    {
        gameObject.SetActive(true); 
        finalScoreText.text = "You LOST!\n" + "You got a score of " + scoreKeeper.GetScore() + ".";
    }

    private void DisableOtherElements()
    {
        foreach (var element in elementsToDisable)
        {
            element.SetActive(false);
        }

        scoreKeeper.SetScore(0);
    }
}
