using UnityEngine;
using UnityEngine.EventSystems;

public class ArraySlotLinkedListDeletion : MonoBehaviour, IDropHandler
{
    public int index;
    public string name;
    private LinkedListForDeletion LinkedListForDeletion;
    private DragDropLinkedListDeletion DragDropLinkedListDeletion;

    public void Start()
    {
        LinkedListForDeletion = FindObjectOfType<LinkedListForDeletion>();
        DragDropLinkedListDeletion = FindObjectOfType<DragDropLinkedListDeletion>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {

            eventData.pointerDrag.transform.position = this.transform.position;
            LinkedListForDeletion.AddValues(eventData.pointerDrag.GetComponent<DraggablePointer>().name, this.index);
        }
    }
}