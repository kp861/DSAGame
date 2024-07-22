using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LinkedListForDeletion : MonoBehaviour
{
    public string[] values;
    public bool[] bools;

    public static LinkedListForDeletion instance;
    public static LinkedListForDeletion Instance
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
            values = new string[3] { "UpArrow", "SideArrow", String.Empty };
            
            bools = new bool[3];
            bools[0] = true;
            bools[1] = true;
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
    public void ModifyBools(string name, bool value)
    {
        if (name == "SideArrow")
        {
            if (bools[2])
            {
                bools[1] = value;
                values[1] = String.Empty;
            }
            
        }
        else if (name == "UpArrow")
        {
            if (bools[2])
            {
                bools[0] = value;
                values[0] = String.Empty;
            }
                
        }
        else if (name == "StraightArrow")
        {
            if (bools[0] && bools[1])
            {
                bools[2] = value;
                values[2] = "StraightArrow";
            }
            
        }
    }
}