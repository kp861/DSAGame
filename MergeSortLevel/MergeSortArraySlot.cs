using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class MergeSortArraySlot : MonoBehaviour, IDropHandler
{
    public int index;
    public int value;
    ListOfValues list;

    void Start()
    {
        list = ListOfValues.Instance;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.position = this.transform.position;
            //Debug.Log(eventData.pointerDrag.GetComponent<DraggableINT>().value);
            Debug.Log(eventData.pointerDrag.GetComponent<DraggableINT>().value);
            Debug.Log(this.index);         
            list.AddToArray(eventData.pointerDrag.GetComponent<DraggableINT>().value, this.index);
            
            
        }
    }  
}
