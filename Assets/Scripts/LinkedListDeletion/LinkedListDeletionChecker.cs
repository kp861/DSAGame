using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LinkedListDeletionChecker : MonoBehaviour
{
    public LinkedListForDeletion LinkedListForDeletion;
    public Button ConfirmationButton;
    private ScoreKeeper scoreKeeper;
    private SceneLoader loader;
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    void Start()
    {
        LinkedListForDeletion = LinkedListForDeletion.Instance;

        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        loader = FindObjectOfType<SceneLoader>();
        Button btn = ConfirmationButton.GetComponent<Button>();

        btn.onClick.AddListener(CheckValues);
    }

    public void CheckValues()
    {
        LinkedListForDeletion.PrintBools();
        List<bool> Bools = LinkedListForDeletion.GetBools();
        string[] vals = LinkedListForDeletion.GetValues();

        foreach (string val in vals)
        {
            Debug.Log(val);
        }

        if (Bools.All(x => x))
        {
            scoreKeeper.DecrementScore(10);
            audioSource2.Play();
            loader.LoadSceneWithDelay("LinkedListDeletion", 1f);
        }

        else if (Bools.Last(x =>x))
        {
            if (Bools[1] || Bools[0])
            {
                scoreKeeper.DecrementScore(10);
                audioSource2.Play();
                loader.LoadSceneWithDelay("LinkedListDeletion", 1f);
            }
            else
            {
                audioSource1.Play();
                scoreKeeper.IncrementScore(10);
                loader.LoadSceneWithDelay("StackLevel", 1f);
            }   
        }
        else
        {
            scoreKeeper.DecrementScore(10);
            audioSource2.Play();
            loader.LoadSceneWithDelay("LinkedListDeletion", 1f);
        }
    }
}
