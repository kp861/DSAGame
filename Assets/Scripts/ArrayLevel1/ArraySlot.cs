using UnityEngine;
using UnityEngine.EventSystems;

public class ArraySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.position = this.transform.position;
            MyArrayManager.Instance.AddElementToArray(eventData.pointerDrag.GetComponent<DraggableINT>().value);
        }
    }
}