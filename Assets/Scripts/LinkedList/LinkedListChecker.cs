using UnityEngine;
using UnityEngine.UI;

public class LinkedListChecker : MonoBehaviour
{
    public LinkedList linkedList;
    public Button confirmButton;
    public AudioSource AudioSource1;
    public AudioSource AudioSource2;
    ScoreKeeper scoreKeeper;
    SceneLoader SceneLoader;
    void Start()
    {
        linkedList = FindObjectOfType<LinkedList>();
        Button btn = confirmButton.GetComponent<Button>();   
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        SceneLoader = FindObjectOfType<SceneLoader>();
    }
    
    public void CheckLinkedList()
    {
        string[] vals = linkedList.GetValues();
        if (vals[0] == "head" && vals[9] == "null")
        {
            if (RestArrayCheck(vals))
            {
                Debug.Log("All true");
                AudioSource1.Play();
                scoreKeeper.IncrementScore(10);
                SceneLoader.LoadSceneWithDelay("LinkedListInsertion", 1f);

            }
            else
            {
                Debug.Log("false");
                AudioSource2.Play();
                scoreKeeper.DecrementScore(10);
                SceneLoader.LoadSceneWithDelay("LinkedListLevel", 1f);
            }
            //return true;
        }
        else
        {
            Debug.Log("false");
            AudioSource2.Play();
            scoreKeeper.DecrementScore(10);
            SceneLoader.LoadSceneWithDelay("LinkedListLevel", 1f);
            //return false;
        }
    }
    public bool RestArrayCheck(string[] vals)
    {
        
        for (int i = 1; i < linkedList.GetCount() - 1; i++)
        {
            if (vals[i] != "data" && vals[i + 1] != "next")
            {
                Debug.Log("incorrect values");
                return false;
            }
            i++;
        }
        Debug.Log("Correct values");
        return true;
    }

}
