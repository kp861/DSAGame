using UnityEngine;
using UnityEngine.UI;

public class TimerForIndexingLevel : MonoBehaviour
{
    [SerializeField] private float TimeToCompleteLevel = 20f;
    private float timerValue;
    public bool isAnswering = false;
    public bool isTimerRunning = false;
    public float fillFraction;
    public delegate void OnTimerEnd();
    public static event OnTimerEnd TimerEnded;
    //public GameObject panel;
    [SerializeField] private Image timerImage;
    private bool hasEnded = false;
    public GameObject panel;
    private void Start()
    {
        ResetTimer();
        timerImage.fillAmount = 1; // Ensure the timer is visible at the start
    }

    void Update()
    {
        //if (panel.active)
        //{
        //    isTimerRunning = false;
        //}
        if (isTimerRunning)
        {
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (isAnswering)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / TimeToCompleteLevel;
            }
            else
            {
                isAnswering = false;
                timerValue = TimeToCompleteLevel;
                // You can add logic here if needed when switching to the next state
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / TimeToCompleteLevel;
            }
            else if (!hasEnded)
            {
                isAnswering = true;
                hasEnded = true;
                HandleGameOver();
                return;
            }
        }

        timerImage.fillAmount = fillFraction;
    }

    private void HandleGameOver()
    {
        Debug.Log("Time's up! Player lost.");
        StopTimer();
    }

    private void ResetTimer()
    {
        timerValue = TimeToCompleteLevel;
        fillFraction = 1; // Ensure the timer starts full
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
        TimerEnded?.Invoke();
    }
}
