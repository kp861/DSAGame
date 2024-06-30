using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class BubbleSortChecker : MonoBehaviour
{

    ScoreKeeper scoreKeeper;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    SceneLoader sceneLoader;
    public Button confirmationButton;
    //[SerializeField] TextMeshProUGUI scoreText;
    private GameObject[] blocks;
    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        Button btn = confirmationButton.GetComponent<Button>();
        btn.onClick.AddListener(CheckArrayValues);
       // scoreText.text = "Score: " + scoreKeeper.GetScore();
        blocks = GameObject.FindGameObjectsWithTag("ArrayElement").OrderBy(go => go.name).ToArray();
    }

    private void CheckArrayValues()
    {
        for (int i = 0; i < blocks.Length - 1; i++)
        {
            int val1 = blocks[i].GetComponent<ArrayBubbleSort>().value;
            int val2 = blocks[i + 1].GetComponent<ArrayBubbleSort>().value;

            if (val1 > val2)
            {
                scoreKeeper.DecrementScore(10);
                audioSource2.Play();
                sceneLoader.LoadSceneWithDelay("BubbleSortLevel", 1f);
                return;
            }
        }
        scoreKeeper.IncrementScore(10);
        audioSource1.Play();
        sceneLoader.LoadSceneWithDelay("MergeSortLevel", 1f);
    }
    
}
