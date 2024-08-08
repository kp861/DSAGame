using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDropLinkedList : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private bool isDroppedInZone = false;
    [SerializeField] Image timerImage;
    Timer timer;
    
    void Start()
    {
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
        if (isDroppedInZone) return;

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (eventData.pointerEnter != null && eventData.pointerEnter.GetComponent<ArraySlotLinkedList>() != null)
        {
            Debug.Log("Dropping Element");
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
}
