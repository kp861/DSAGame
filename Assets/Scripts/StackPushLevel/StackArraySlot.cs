using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class StackArraySlot : MonoBehaviour, IDropHandler
{
    public int index;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.position = this.transform.position;
            Debug.Log(eventData.pointerDrag.GetComponent<DraggableINT>().value);
        }
    }
}
