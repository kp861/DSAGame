using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayCheckBinarySearch : MonoBehaviour
{
    //Representation of revealed values - 75/ 6/ 20/ 9. Each book value represent a number
    //e.g. 75 - true - it means value was revealed.
    private bool[] ArrayCheckBools = new bool[13];
    ScoreKeeper score;

    public bool[] GetBools()
    {
        return ArrayCheckBools;
    }
    private Elements element;
    public ScoreKeeper scoreKeeper;
    SceneLoader sceneLoader;
    

    private void Start()
    {
        
        element = FindObjectOfType<Elements>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        score = FindObjectOfType<ScoreKeeper>();
    }

    public bool CheckArray(int val, int index)
    {
        if (val == 75)
        {
            if (!ArrayCheckBools[index])
            {
                ArrayCheckBools[index] = true;
                
                return true;
            }
        }
        else if (val == 6)
        {
            if(ArrayCheckBools[6])
            {

                ArrayCheckBools[index] = true;
                
                return true;
            }
        }
        else if (val == 20)
        {
            if (ArrayCheckBools[6] &&  ArrayCheckBools[2])
            {
                ArrayCheckBools[index] = true;
                
                return true;
            }
        }
        else if (val == 9)
        {
            if (ArrayCheckBools[6] && ArrayCheckBools[2] && ArrayCheckBools[4])
            {
                ArrayCheckBools[index] = true;
                score.IncrementScore(15);
                return true;
            }
        }
        score.DecrementScore(15);
        return false;
        
    }

    
}
