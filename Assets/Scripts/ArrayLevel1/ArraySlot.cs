using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class ArraySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.position = this.transform.position;
            Debug.Log(eventData.pointerDrag.GetComponent<DraggableINT>().value);

            MyArrayManager.Instance.AddElementToArray(eventData.pointerDrag.GetComponent<DraggableINT>().value);
        }
    }
}
//joystick button 0