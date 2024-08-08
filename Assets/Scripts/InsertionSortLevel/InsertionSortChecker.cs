using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InsertionSortChecker : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    SceneLoader sceneLoader;
    public Button confirmationButton;
    private GameObject[] blocks;
    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        Button btn = confirmationButton.GetComponent<Button>();
        btn.onClick.AddListener(CheckArrayValues);
        blocks = GameObject.FindGameObjectsWithTag("ArrayElement").OrderBy(go => go.name).ToArray();
    }

    private void CheckArrayValues()
    {
        for (int i = 0; i < blocks.Length - 1; i++)
        {
            int val1 = blocks[i].GetComponent<ArrayInsertionSort>().value;
            int val2 = blocks[i + 1].GetComponent<ArrayInsertionSort>().value;

            if (val1 > val2)
            {
                scoreKeeper.DecrementScore(10);
                audioSource2.Play();
                sceneLoader.LoadSceneWithDelay("InsertionSortLevel", 1f);
                return;
            }
        }
        scoreKeeper.IncrementScore(10);
        audioSource1.Play();
        sceneLoader.LoadSceneWithDelay("MergeSortLevel", 1f);
    } 
}
