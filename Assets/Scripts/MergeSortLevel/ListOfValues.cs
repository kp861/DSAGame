using UnityEngine;

public class ListOfValues : MonoBehaviour
{
    private static ListOfValues instance;
    public int[] values;
    public static ListOfValues Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ListOfValues>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            values = new int[6];
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Destroy duplicate
        }
    }

    public int[] GetArray()
    {
        return values;
    }

    public void AddToArray(int value, int index)
    {

        if (index >= 0 && index < values.Length)
        {
            values[index] = value;
        }
    }

    public void ResetArray()
    {
        values = new int[6];
    }
}
