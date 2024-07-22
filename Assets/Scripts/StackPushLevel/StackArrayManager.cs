using System.Collections.Generic;
using UnityEngine;

public class StackArrayManager : MonoBehaviour
{
    public static StackArrayManager Instance { get; private set; }

    //private int[] elements;
    public bool[] bools;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            //elements = new int[6];
            bools = new bool[6];
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddElementToArray(int index)
    {
        //elements[index] = value;
        bools[index] = true;
        Debug.Log("Element added: ");
    }

    public bool[] GetArray()
    {
        return bools;
    }

    public void Reset()
    {
        Destroy(gameObject);
    }
}