using UnityEngine;
using UnityEngine.EventSystems;

public class BinarySearchElements : MonoBehaviour, IPointerDownHandler
{
    public int index;
    public int value;
    public GameObject BinarySearchInt;
    ArrayCheckBinarySearch ArrayCheckBinarySearch;
    SceneLoader sceneLoader;
    public AudioSource AudioSource1;
    public AudioSource AudioSource2;

    private void Start()
    {
        BinarySearchInt.SetActive(false);
        ArrayCheckBinarySearch = FindObjectOfType<ArrayCheckBinarySearch>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        index = eventData.pointerEnter.GetComponent<BinarySearchElements>().index;
        value = eventData.pointerEnter.GetComponent<BinarySearchElements>().value;
        if (ArrayCheckBinarySearch.CheckArray(value, index))
        {
            BinarySearchInt.SetActive(true);
            AudioSource1.Play();
            if (value == 9)
            {
                sceneLoader.LoadSceneWithDelay("LinkedListLevel", 1f);
            }
        }
        else
        {
            AudioSource2.Play();
        } 
    }
}
