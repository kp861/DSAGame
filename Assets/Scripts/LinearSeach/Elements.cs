using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Elements : MonoBehaviour, IPointerDownHandler
{
    public int index;
    public int value;
    public GameObject LinearSearchInt;
    ArrayCheckLinSearch arrayCheckLinSearch;
    SceneLoader sceneLoader;

    private void Start()
    {
        LinearSearchInt.SetActive(false);
        arrayCheckLinSearch = FindObjectOfType<ArrayCheckLinSearch>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        
        arrayCheckLinSearch.ModifyArray(index);
        if(arrayCheckLinSearch.CheckArray(value, index))
        {
            if (value == 10)
            {
                LinearSearchInt.SetActive(true);
                sceneLoader.LoadSceneWithDelay("BinarySearchLevel", 2f);
            }
            else
            {
                LinearSearchInt.SetActive(true);
            }
            
            
        }
        
    }
}
