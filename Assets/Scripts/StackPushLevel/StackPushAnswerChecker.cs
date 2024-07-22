using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class StackPushAnswerChecker : MonoBehaviour
{

    public Button confirmationButton;
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    public Timer timer;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    SceneLoader sceneLoader;


    private void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        Button btn = confirmationButton.GetComponent<Button>();
        btn.onClick.AddListener(CheckArrayValues);
        scoreText.text = "Score: " + scoreKeeper.GetScore();
    }

    private void Update()
    {
        scoreText.text = "Score: " + scoreKeeper.GetScore();
    }

    private void CheckArrayValues()
    {
        bool[] arr = StackArrayManager.Instance.GetArray();
        if (arr[5])
        {
            audioSource2.Play();
            scoreKeeper.DecrementScore(10);
            Debug.Log("Stack Overflow");
            
            sceneLoader.LoadSceneWithDelay("StackLevel", 1f);
            return;
        }

        if (!arr[4])
        {
            audioSource2.Play();
            Debug.Log("There is still some space left in stack");
        }


        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (!arr[i])
            {
                audioSource2.Play();
                scoreKeeper.DecrementScore(10);
                Debug.Log("There are empty stack values");
                
                sceneLoader.LoadSceneWithDelay("StackLevel", 1f);
                return;
            }
        }

        audioSource1.Play();
        scoreKeeper.IncrementScore(10);
        sceneLoader.LoadSceneWithDelay("StackLevelPop", 1f);
        return;


    }
}