using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DragDropLinkedListInsertion : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private bool isDroppedInZone = false;
    [SerializeField] Image timerImage;
    private RectTransform StraightArrowPosition;
    Timer timer;
    private LinkedListForInsertion linkedListForInsertion;

    void Start()
    {
        linkedListForInsertion = FindObjectOfType<LinkedListForInsertion>();
        timer = FindObjectOfType<Timer>();
        if (timer == null)
        {
            Debug.LogError("Timer component not found in the scene.");
        }
    }
    void Update()
    {
        if (timer != null)
        {
            timerImage.fillAmount = timer.fillFraction;
        }
    }
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        StraightArrowPosition = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isDroppedInZone) return;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDroppedInZone) return;
        rectTransform.anchoredPosition += eventData.delta;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("Ending Drag");
        if (isDroppedInZone) return;

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (eventData.pointerDrag.gameObject.GetComponent<DraggablePointer>().name == "StraightArrow" &&
            eventData.pointerEnter.GetComponent<ArraySlotLinkedListInsertion>() == null)
        {
            //Debug.Log("Modifying Arrow");
            linkedListForInsertion.ModifyBools(4, false);
            isDroppedInZone = true;
        }
        else if (eventData.pointerEnter != null && eventData.pointerEnter.GetComponent<ArraySlotLinkedListInsertion>() != null)
        {
            isDroppedInZone = true;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop");
    }

    public void ChangeDropZone(bool val)
    {
        isDroppedInZone = val;
    }
}
