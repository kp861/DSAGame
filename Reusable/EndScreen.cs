using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] GameObject[] elementsToDisable; // Add references to all elements to disable
    ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        Timer.TimerEnded += OnTimerEnded; // Subscribe to the TimerEnded event
        gameObject.SetActive(false); // Initially hide the end screen
        Debug.Log("Reached Start");
    }

    void OnDestroy()
    {
        Timer.TimerEnded -= OnTimerEnded; // Unsubscribe from the TimerEnded event
        Debug.Log("Reached OnDestroy");
    }

    private void OnTimerEnded()
    {
        ShowFinalScore();
        DisableOtherElements();
        Debug.Log("Reached OnTimerEnded");
    }

    public void ShowFinalScore()
    {
        gameObject.SetActive(true); // Show the end screen
        finalScoreText.text = "You LOST!\n" + "You got a score of " + scoreKeeper.GetScore() + ".";
        Debug.Log("Reached ShowFinalScore");
    }

    private void DisableOtherElements()
    {
        foreach (var element in elementsToDisable)
        {
            element.SetActive(false);
        }

        scoreKeeper.SetScore(0);
        Debug.Log("Reached DisableOtherElements");
    }
}
