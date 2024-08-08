using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float TimeToCompleteLevel = 20f;
    private float timerValue;
    public bool isAnswering = false;
    public bool isTimerRunning = false;
    public float fillFraction;
    public delegate void OnTimerEnd();
    public static event OnTimerEnd TimerEnded;
    public GameObject panel;
    [SerializeField] public Image timerImage;
    private bool hasEnded = false;

    private void Start()
    {
        ResetTimer();
        timerImage.fillAmount = 1; 
    }

    void Update()
    {
        if (panel.active)
        {
            isTimerRunning = false;
        }
        if (isTimerRunning)
        {
            UpdateTimer();
        }
        else
        {
            CheckForMouseClick();
        }

    }

    private void CheckForMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsPointerOverButton())
            {
                StartTimer();
            }
        }
    }

    private bool IsPointerOverButton()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, raycastResults);

            foreach (RaycastResult result in raycastResults)
            {
                if (result.gameObject.GetComponent<Button>() != null)
                {
                    return true;
                }
            }
        }
        return false;
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
        StopTimer();
    }

    private void ResetTimer()
    {
        timerValue = TimeToCompleteLevel;
        fillFraction = 1;
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
