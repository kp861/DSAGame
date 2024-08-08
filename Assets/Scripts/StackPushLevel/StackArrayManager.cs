using UnityEngine;

public class StackArrayManager : MonoBehaviour
{
    public static StackArrayManager Instance { get; private set; }

    public bool[] bools;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            bools = new bool[6];
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddElementToArray(int index)
    {
        bools[index] = true;
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