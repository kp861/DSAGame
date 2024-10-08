using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class StackPopAnswerChecker : MonoBehaviour
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
        List<bool> arr = StackPopArrayManager.Instance.GetArray().ToList();
        
        if (arr.Skip(1).All(x => !x))
        {
            audioSource1.Play();
            scoreKeeper.IncrementScore(10);
            sceneLoader.LoadSceneWithDelay("FinishScene", 0.5f);
        }
        else
        {
            scoreKeeper.DecrementScore(10);
            audioSource2.Play();
        }
    }
}