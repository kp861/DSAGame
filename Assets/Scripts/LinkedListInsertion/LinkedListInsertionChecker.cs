using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LinkedListInsertionChecker : MonoBehaviour
{
    public LinkedListForInsertion LinkedListForInsertion;
    public Button ConfirmationButton;
    private ScoreKeeper scoreKeeper;
    private SceneLoader loader;
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    void Start()
    {
        // Ensure LinkedListForInsertion singleton instance is correctly set
        LinkedListForInsertion = LinkedListForInsertion.Instance;

        // Ensure ScoreKeeper and SceneLoader are correctly set
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        loader = FindObjectOfType<SceneLoader>();
        Button btn = ConfirmationButton.GetComponent<Button>();

        // Remove all listeners and add CheckValues listener to the button
        //ConfirmationButton.onClick.RemoveAllListeners();
        btn.onClick.AddListener(CheckValues);
    }

    public void CheckValues()
    {
        Debug.Log("Printing all bools");
        LinkedListForInsertion.PrintBools();
        List<bool> Bools = LinkedListForInsertion.GetBools();
        string[] vals = LinkedListForInsertion.GetValues();

        Debug.Log("Printing all vals");
        foreach (string val in vals)
        {
            Debug.Log(val);
        }

        if (Bools.All(x => x))
        {
            Debug.Log("InCorrect");
            scoreKeeper.DecrementScore(10);
            audioSource2.Play();
            loader.LoadSceneWithDelay("LinkedListInsertion", 1f);
        }

        else if (Bools.SkipLast(1).All(x => x))
        {
            Debug.Log("Correct");
            audioSource1.Play();
            scoreKeeper.IncrementScore(10);
            loader.LoadSceneWithDelay("LinkedListDeletion", 1f);
        }
        else
        {
            Debug.Log("InCorrect");
            scoreKeeper.DecrementScore(10);
            audioSource2.Play();
            loader.LoadSceneWithDelay("LinkedListInsertion", 1f);
        }
    }
}
