using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class AnswerCheckup : MonoBehaviour
{

    public Button confirmationButton;
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    public Timer timer;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    SceneLoader sceneLoader;
    //private List<Transform> draggableObjects = new List<Transform>();
    //private Dictionary<Transform, Vector2> initialPositions = new Dictionary<Transform, Vector2>();

    private void Start()
    {
        //foreach (var draggable in FindObjectsOfType<DragAndDrop>())
        //{
        //Transform draggableTransform = draggable.transform;
        //draggableObjects.Add(draggableTransform);
        //initialPositions[draggableTransform] = draggableTransform.position;
        //}

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
            Debug.Log("Array is empty.");
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
            Debug.Log("All values are the same. Correct!");
            scoreKeeper.IncrementScore(10);
            Debug.Log(scoreKeeper.GetScore());
            audioSource1.Play();
            sceneLoader.LoadSceneWithDelay("ArrayIndexing", 1f);
        }
        else
        {
            Debug.Log("Values are different. Incorrect!");
            scoreKeeper.DecrementScore(10);
            //foreach (Transform draggable in draggableObjects)
            //{
            //if (initialPositions.ContainsKey(draggable))
            //{
            //draggable.position = initialPositions[draggable];
            //}
            //}
            audioSource2.Play();
            sceneLoader.LoadSceneWithDelay("ArrayLevel1", 1f);

        }
    }
}