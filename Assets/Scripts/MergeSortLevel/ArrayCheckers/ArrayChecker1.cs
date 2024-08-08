using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ArrayChecker1 : MonoBehaviour
{
    public Button confirmationButton1;
    public Button confirmationButton2;
    public Button confirmationButton3;
    public Button confirmationButton4;
    public Button confirmationButton5;
    public Button confirmationButton6;
    public ScoreKeeper scoreKeeper;
    public AudioSource audioSource1;
    public AudioSource audioSource2; // This is not used currently but kept for future use
    bool[] BoolsArr = new bool[6] { false, false, false, false, false, false };


    public GameObject[] items; 
    private Vector3[] initialPositions;

    private void Start()
    {
        // Initialize the initial positions array
        initialPositions = new Vector3[items.Length];
        for (int i = 0; i < items.Length; i++)
        {
            initialPositions[i] = items[i].GetComponent<RectTransform>().anchoredPosition;
        }

        int[] valuesForButton1 = { 6, 5, 15, 10, 9, 1 };
        int[] valuesForButton2 = { 6, 5, 15, 10, 9, 1 };
        int[] valuesForButton3 = { 6, 5, 15, 10, 9, 1 };
        int[] valuesForButton4 = { 6, 5, 15, 10, 1, 9 };
        int[] valuesForButton5 = { 5, 6, 15, 1, 9, 10 };
        int[] valuesForButton6 = { 1, 5, 6, 9, 10, 15 };

        confirmationButton1.onClick.AddListener(() => ArrayCheck(valuesForButton1, 0));
        confirmationButton2.onClick.AddListener(() => ArrayCheck(valuesForButton2, 1));
        confirmationButton3.onClick.AddListener(() => ArrayCheck(valuesForButton3, 2));
        confirmationButton4.onClick.AddListener(() => ArrayCheck(valuesForButton4, 3));
        confirmationButton5.onClick.AddListener(() => ArrayCheck(valuesForButton5, 4));
        confirmationButton6.onClick.AddListener(() => ArrayCheck(valuesForButton6, 5));
    }

    public void ArrayCheck(int[] expectedValues, int index)
    {
        int[] arr = ListOfValues.Instance.GetArray();
        bool arraysMatch = arr.Length == expectedValues.Length;

        for (int i = 0; i < expectedValues.Length && arraysMatch; i++)
        {
            if (arr[i] != expectedValues[i])
            {
                arraysMatch = false;
            }
        }

        if (arraysMatch)
        {
            if (audioSource1 != null)
            {
                audioSource1.Play();
                scoreKeeper.IncrementScore(5);
                BoolsArr[index] = true;
            }

            if (index == 5 && BoolsArr.All(x => x))
            {
                scoreKeeper.IncrementScore(5);
                FindObjectOfType<SceneLoader>().LoadSceneWithDelay("LinearSearchLevel", 1f);
            }
        }
        else
        {
            if (audioSource2 != null)
            {
                audioSource2.Play();
            }
            scoreKeeper.DecrementScore(5);
            BoolsArr[index] = false;
            ResetItemsToInitialPositions();
        }

        ListOfValues.Instance.ResetArray();
    }

    private void ResetItemsToInitialPositions()
    {
        foreach (var item in items)
        {
            item.GetComponent<DragAndDropMergeSort>().ResetPosition();
        }
    }
}
