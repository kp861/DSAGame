using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDropLinkedListDeletion : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private bool isDroppedInZone = false;
    [SerializeField] Image timerImage;
    private RectTransform StraightArrowPosition;
    Timer timer;
    private LinkedListForDeletion linkedListForDeletion;

    void Start()
    {
        linkedListForDeletion = FindObjectOfType<LinkedListForDeletion>();
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
        Debug.Log("OnBeginDrag");
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
        if (isDroppedInZone) return;

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        
        if (eventData.pointerEnter.GetComponent<ArraySlotLinkedListDeletion>() == null)
        {
            string name = eventData.pointerDrag.gameObject.GetComponent<DraggablePointer>().name;
            linkedListForDeletion.ModifyBools(name, false);
            isDroppedInZone = true;
        }
        else if (eventData.pointerDrag.gameObject.GetComponent<DraggablePointer>().name == "StraightArrow"
            && eventData.pointerEnter.GetComponent<ArraySlotLinkedListDeletion>() != null)
        {
            linkedListForDeletion.ModifyBools("StraightArrow", true);
            isDroppedInZone = true;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
    }

    public void ChangeDropZone(bool val)
    {
        isDroppedInZone = val;
    }
}
