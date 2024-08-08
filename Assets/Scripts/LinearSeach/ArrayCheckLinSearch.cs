using UnityEngine;

public class ArrayCheckLinSearch : MonoBehaviour
{
    private bool[] ArrayCheckBools = new bool[10];
    private Elements element;
    public ScoreKeeper scoreKeeper;
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    private void Start()
    {
        element = FindObjectOfType<Elements>();
    }

    public bool CheckArray(int val, int index)
    {
        if (val == 10 && !ElementsToTheLeft(index))
        {
            scoreKeeper.DecrementScore(30);
            audioSource2.Play();
            return true;
        }

        else if (val == 10 && ElementsToTheLeft(index))
        {
            audioSource1.Play();
            scoreKeeper.IncrementScore(20);
            return true;  
        }

        else if (!ElementsToTheLeft(index))
        {
            scoreKeeper.DecrementScore(15);
            audioSource2.Play();
            return false;
        }

        else
        {
            audioSource1.Play();
            return true;
        }  
    }

    private bool ElementsToTheLeft(int index)
    {
        for (int i = 0; i < index; i++)
        {
            if (ArrayCheckBools[i] != true)
            {    
                return false;
            }
        }
        return true;
    }
    public void ModifyArray(int index)
    {
        ArrayCheckBools[index] = true;
    }
}
