using UnityEngine;

public class LinkedList : MonoBehaviour
{
    public string[] values;
    private static LinkedList instance;
    public static LinkedList Instance
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
            values = new string[10];
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
}
