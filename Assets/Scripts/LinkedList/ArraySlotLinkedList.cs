using UnityEngine;
using UnityEngine.EventSystems;

public class ArraySlotLinkedList : MonoBehaviour, IDropHandler
{
    public int index;
    public string name;
    private LinkedList linkedList;

    public void Start()
    {
        linkedList = FindObjectOfType<LinkedList>();    
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.position = this.transform.position;
            linkedList.AddValues(eventData.pointerDrag.GetComponent<DraggablePointer>().name, this.index);
        }
    }
}