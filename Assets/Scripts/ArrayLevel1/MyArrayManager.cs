using System.Collections.Generic;
using UnityEngine;
public class MyArrayManager : MonoBehaviour
{
    public static MyArrayManager Instance { get; private set; }
    private List<int> elements;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            elements = new List<int>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddElementToArray(int value)
    {
        elements.Add(value);
    }

    public int[] GetArray()
    {
        return elements.ToArray();
    }

    public void Reset()
    {
        Destroy(gameObject);
    }
}