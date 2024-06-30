using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfValues : MonoBehaviour
{
    // Singleton instance
    private static ListOfValues instance;
    public int[] values;
    public static ListOfValues Instance
    {
        get
        {
            if (instance == null)
            {
                // Find the instance in the scene
                instance = FindObjectOfType<ListOfValues>();

                // If not found, create a new one
                //if (instance == null)
                //{
                    //GameObject singletonObject = new GameObject();
                    //instance = singletonObject.AddComponent<ListOfValues>();
                //}
            }
            return instance;
        }
    }

    // Prevents duplication of the singleton instance
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
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
