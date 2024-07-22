using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayCheckLinSearch : MonoBehaviour
{
    private bool[] ArrayCheckBools = new bool[10];

    private Elements element;
    public ScoreKeeper scoreKeeper;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    //SceneLoader sceneLoader;

    private void Start()
    {
        element = FindObjectOfType<Elements>();
        //sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public bool CheckArray(int val, int index)
    {
        if (val == 10 && !ElementsToTheLeft(index))
        {
            Debug.Log("Answer correct, but there are unchecked elements to the left");
            scoreKeeper.DecrementScore(30);
            audioSource2.Play();
            //sceneLoader.LoadSceneWithDelay("BinarySearchLevel", 1f);
            return true;
        }

        else if (val == 10 && ElementsToTheLeft(index))
        {
            Debug.Log("Founded");
            audioSource1.Play();
            scoreKeeper.IncrementScore(20);
            //sceneLoader.LoadSceneWithDelay("BinarySearchLevel", 1f);
            return true;
            
        }

        else if (!ElementsToTheLeft(index))
        {
            Debug.Log("There are unchecked elements left to the Array");
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
        Debug.Log("Updated bool array");
        ArrayCheckBools[index] = true;
    }
}
