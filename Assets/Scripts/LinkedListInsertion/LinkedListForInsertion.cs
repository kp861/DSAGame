using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LinkedListForInsertion : MonoBehaviour
{
    public string[] values;
    public bool[] bools;

    public static LinkedListForInsertion instance;
    public static LinkedListForInsertion Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
            values = new string[5];
            values[4] = "StraightArrow";
            bools = new bool[5];
            bools[4] = true;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public string[] GetValues()
    {
        return values;
    }

    public void AddValues(string value, int index)
    {

        values[index] = value;

        if (value == "UpArrow" && index == 3)
        {
            Debug.Log("UpArrow And Index3");
            if (bools[2] == false && bools[4] == true)
            {
                Debug.Log("UpArrowCorrect");
                bools[2] = true;
            }
        }

        else if (value == "SideArrow" && index == 2)
        {
            if (bools[2] == true && bools[4] == true)
            {
                Debug.Log("SideArrowCorrect");
                bools[3] = true;
            }
        }

        else if (value == "StraightArrow" && index == 4)
        {
            if (bools[2] == true && bools[3] == true)
            {
                Debug.Log("StraightArrowCorrect");
                bools[5] = true;
            }
        }
        else if (value == "data" && index == 0)
        {
            Debug.Log("dataCorrect");
            bools[0] = true;
        }

        else if (value == "next" && index == 1)
        {
            Debug.Log("nextCorrect");
            bools[1] = true;
        }
    }

    public int GetCount()
    {
        return values.Length;
    }

    public List<bool> GetBools()
    {
        List<bool> lst = bools.ToList();
        return lst;
    }
    public void PrintBools()
    {
        foreach (bool b in bools)
        {
            Debug.Log(b);
        }
    }
    public void ModifyBools(int index, bool value)
    {
        bools[index] = value;
        values[index] = String.Empty;

    }
}