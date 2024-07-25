using System.Collections.Generic;
using UnityEngine;

public class StackPopArrayManager : MonoBehaviour
{
    public static StackPopArrayManager Instance { get; private set; }

    public bool[] bools;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            bools = new bool[6] {true, true, true, true, true, true};
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RemoveElementFromArray(int index)
    {
        //elements[index] = value;
        bools[index] = false;
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