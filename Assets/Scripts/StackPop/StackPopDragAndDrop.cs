using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StackPopDragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private RectTransform rectTransform;
    private Vector2 originalPosition;
    private CanvasGroup canvasGroup;
    private bool isDroppedInZone = false;
    [SerializeField] Image timerImage;
    public Timer timer;
    private bool OnValidDrop = false;
    public AudioSource AudioSource;
    private ScoreKeeper scoreKeeper;
    
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        if (timer == null)
        {
            Debug.LogError("Timer component not found in the scene.");
        }
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
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
        if (eventData.pointerEnter != null && eventData.pointerEnter.GetComponent<StackPopArraySlot>() != null)
        {
            isDroppedInZone = false;
            eventData.pointerDrag.transform.position = originalPosition;
            OnValidDrop = false;
        }

        else if (eventData.pointerEnter != null && eventData.pointerEnter.GetComponent<StackPopArraySlot>() == null)
        {
            int val = eventData.pointerDrag.GetComponent<DraggableINT>().value;
            bool[] bools = StackPopArrayManager.Instance.GetArray();
            
            if (val < 6 && val > 0)
            {
                for (int i = val + 1; i < bools.Length; i++)
                {
                    if (bools[i])
                    {
                        this.transform.position = originalPosition;
                        scoreKeeper.DecrementScore(5);
                        AudioSource.Play();
                        return;
                    }
                }

                for (int i = val - 1; i >= 0; i--)
                {
                    if (!bools[i])
                    {
                        scoreKeeper.DecrementScore(5);
                        AudioSource.Play();
                        this.transform.position = originalPosition;
                        return;
                    }
                }
            }

            if (val == 0)
            {
                if (bools[val + 1] == true)
                {
                    scoreKeeper.DecrementScore(5);
                    AudioSource.Play();
                    this.transform.position = originalPosition;
                    return;
                }
            }
            isDroppedInZone = true;    
            StackPopArrayManager.Instance.RemoveElementFromArray(val);
            OnValidDrop = true;
        }

        else if (eventData.pointerEnter != null && eventData.pointerEnter.GetComponent<StackPopArraySlot>() != null)
        {
            isDroppedInZone = false;
            eventData.pointerDrag.transform.position = originalPosition;
            OnValidDrop = false;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        originalPosition = this.transform.position;
        Debug.Log("OnPointerDown");

    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null && eventData.pointerEnter.GetComponent<StackPopArraySlot>() != null)
        {
            scoreKeeper.DecrementScore(5);
            AudioSource.Play();
            eventData.pointerDrag.transform.position = this.transform.position;
        }
        else if (eventData.pointerDrag != null && eventData.pointerEnter.GetComponent<StackPopArraySlot>() == null)
        {
            if (OnValidDrop)
            {
                eventData.pointerDrag.transform.position = this.transform.position;
                Debug.Log(eventData.pointerDrag.GetComponent<DraggableINT>().value);
            }

            else
            {
                eventData.pointerDrag.transform.position = originalPosition;
            }
        }
    }
}