using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerCheckup : MonoBehaviour
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
        int[] array = MyArrayManager.Instance.GetArray();

        if (array.Length < 6)
        {
            audioSource2.Play();
            scoreKeeper.DecrementScore(10);
            sceneLoader.LoadSceneWithDelay("ArrayLevel1", 1f);
            return;
        }

        bool allSame = true;
        int firstValue = array[0];

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] != firstValue)
            {
                allSame = false;
                
                break;
            }
        }

        if (allSame)
        {
            scoreKeeper.IncrementScore(10);
            audioSource1.Play();
            sceneLoader.LoadSceneWithDelay("ArrayIndexing", 1f);
        }
        else
        {
            scoreKeeper.DecrementScore(10);
            audioSource2.Play();
            sceneLoader.LoadSceneWithDelay("ArrayLevel1", 1f);
        }
    }
}