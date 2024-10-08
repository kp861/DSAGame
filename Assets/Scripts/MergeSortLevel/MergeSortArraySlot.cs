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
            list.AddToArray(eventData.pointerDrag.GetComponent<DraggableINT>().value, this.index);   
        }
    }  
}
