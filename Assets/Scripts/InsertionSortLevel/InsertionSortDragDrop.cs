using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class InsertionSortDragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;
    private Transform originalParent;
    private ArrayInsertionSort originalSlot;
    private bool isDroppedInZone = false;
    private ScoreKeeper scoreKeeper;
    private GameObject[] blocks;
    public AudioSource as1;
    public AudioSource as2;
    public GameObject obj; //We will Set Parent this element for Draggable elements to appear on top

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
        blocks = GameObject.FindGameObjectsWithTag("ArrayElement").OrderBy(go => go.name).ToArray();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition;
        originalParent = transform.parent;
        originalSlot = originalParent.GetComponent<ArrayInsertionSort>();
        transform.SetParent(obj.transform, true);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        transform.SetParent(obj.transform, true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
        transform.SetParent(obj.transform, true);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(originalParent);
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (eventData.pointerEnter != null && eventData.pointerEnter.transform.parent.GetComponent<ArrayInsertionSort>() != null)
        {
            ArrayInsertionSort targetSlot = eventData.pointerEnter.transform.parent.GetComponent<ArrayInsertionSort>();

            if (ChecksForSwap(originalSlot, targetSlot))
            {
                scoreKeeper.IncrementScore(1);
                if (as1 != null)
                {
                    as1.Play();
                }
                else
                {
                    Debug.LogWarning("as1 is null, cannot play sound.");
                }
                SwapElements(originalSlot, targetSlot);
            }
            else
            {
                scoreKeeper.DecrementScore(1);
                if (as2 != null)
                {
                    as2.Play();
                }
                else
                {
                    Debug.LogWarning("as2 is null, cannot play sound.");
                }
                ResetPosition();
            }
        }
        else
        {
            ResetPosition();
            if (as2 != null)
            {
                as2.Play();
            }
            else
            {
                Debug.LogWarning("as2 is null, cannot play sound.");
            }
            scoreKeeper.DecrementScore(1);
        }
    }

    private void SwapElements(ArrayInsertionSort slot1, ArrayInsertionSort slot2)
    {
        int tempValue = slot1.value;
        slot1.value = slot2.value;
        slot2.value = tempValue;

        Transform temp = slot1.transform.GetChild(0);
        slot2.transform.GetChild(0).SetParent(slot1.transform, false);
        slot1.transform.GetChild(0).SetParent(slot2.transform, false);
        slot2.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        slot1.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
    private void ResetPosition()
    {
        rectTransform.anchoredPosition = originalPosition;
        transform.SetParent(originalParent);
        transform.SetSiblingIndex(originalSlot.transform.GetSiblingIndex());
    }

    private bool ChecksForSwap(ArrayInsertionSort originalSlot, ArrayInsertionSort targetSlot)
    {
        if (originalSlot.value < targetSlot.value)
        {
            return false;
        }

        if (originalSlot.index > targetSlot.index)
        {
            return false;
        }

        for (int i = 0; i < originalSlot.index; i++)
        {
            int currentValue = blocks[i].GetComponent<ArrayInsertionSort>().value;
            int nextValue = blocks[i + 1].GetComponent<ArrayInsertionSort>().value;

            if (currentValue > nextValue)
            {
                return false;
            }
        }
        return true;
    }
}