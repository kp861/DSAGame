using UnityEngine;
using UnityEngine.EventSystems;

public class ArraySlotLinkedListInsertion : MonoBehaviour, IDropHandler
{
    public int index;
    public string name;
    private LinkedListForInsertion LinkedListForInsertion;
    private DragDropLinkedListInsertion DragDropLinkedListInsertion;

    public void Start()
    {
        LinkedListForInsertion = FindObjectOfType<LinkedListForInsertion>();
        DragDropLinkedListInsertion = FindObjectOfType<DragDropLinkedListInsertion>();  
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {

            eventData.pointerDrag.transform.position = this.transform.position;
            LinkedListForInsertion.AddValues(eventData.pointerDrag.GetComponent<DraggablePointer>().name, this.index);
            //LinkedListForInsertion.ModifyBools(index, true);
        }
    }
}