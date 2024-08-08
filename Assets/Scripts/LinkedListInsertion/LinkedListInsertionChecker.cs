using System.Collections.Generic;
using System.Linq;
using UnityEngine;
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
        LinkedListForInsertion = LinkedListForInsertion.Instance;
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        loader = FindObjectOfType<SceneLoader>();
        Button btn = ConfirmationButton.GetComponent<Button>();
        btn.onClick.AddListener(CheckValues);
    }

    public void CheckValues()
    {
        LinkedListForInsertion.PrintBools();
        List<bool> Bools = LinkedListForInsertion.GetBools();
        string[] vals = LinkedListForInsertion.GetValues();

        foreach (string val in vals)
        {
            Debug.Log(val);
        }

        if (Bools.All(x => x))
        {
            scoreKeeper.DecrementScore(10);
            audioSource2.Play();
            loader.LoadSceneWithDelay("LinkedListInsertion", 1f);
        }

        else if (Bools.SkipLast(1).All(x => x))
        {
            audioSource1.Play();
            scoreKeeper.IncrementScore(10);
            loader.LoadSceneWithDelay("LinkedListDeletion", 1f);
        }
        else
        {
            scoreKeeper.DecrementScore(10);
            audioSource2.Play();
            loader.LoadSceneWithDelay("LinkedListInsertion", 1f);
        }
    }
}
