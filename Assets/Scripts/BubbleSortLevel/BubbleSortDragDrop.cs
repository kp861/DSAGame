using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class BubbleSortDragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;
    private Transform originalParent;
    private ArrayBubbleSort originalSlot;
    private bool isDroppedInZone = false;
    private ScoreKeeper scoreKeeper;
    private GameObject[] blocks;
    public AudioSource as1;
    public AudioSource as2;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
        blocks = GameObject.FindGameObjectsWithTag("ArrayElement").OrderBy(go => go.name).ToArray();

        // Debug logs to check if AudioSources are assigned
        Debug.Log("AudioSource as1 is " + (as1 != null ? "assigned" : "null"));
        Debug.Log("AudioSource as2 is " + (as2 != null ? "assigned" : "null"));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        originalPosition = rectTransform.anchoredPosition;
        originalParent = transform.parent;
        originalSlot = originalParent.GetComponent<ArrayBubbleSort>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        transform.SetParent(canvasGroup.transform, true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (eventData.pointerEnter != null && eventData.pointerEnter.transform.parent.GetComponent<ArrayBubbleSort>() != null)
        {
            ArrayBubbleSort targetSlot = eventData.pointerEnter.transform.parent.GetComponent<ArrayBubbleSort>();

            if (ChecksForSwap(originalSlot, targetSlot))
            {
                scoreKeeper.IncrementScore(2);
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
                scoreKeeper.DecrementScore(2);
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

    private void SwapElements(ArrayBubbleSort slot1, ArrayBubbleSort slot2)
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

    private bool ChecksForSwap(ArrayBubbleSort originalSlot, ArrayBubbleSort targetSlot)
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
            int currentValue = blocks[i].GetComponent<ArrayBubbleSort>().value;
            int nextValue = blocks[i + 1].GetComponent<ArrayBubbleSort>().value;

            if (currentValue > nextValue)
            {
                return false;
            }
        }
        return true;
    }
}