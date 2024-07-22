using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Timer;

public class StackPushDragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private RectTransform rectTransform;
    private Vector3 originalPosition;
    private CanvasGroup canvasGroup;
    private bool isDroppedInZone = false;
    [SerializeField] Image timerImage;
    Timer timer;
    public AudioSource audiosource1;    

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
        originalPosition = this.transform.position;
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

        if (eventData.pointerEnter != null && eventData.pointerEnter.GetComponent<StackArraySlot>() != null)
        {
            bool[] bools = StackArrayManager.Instance.GetArray();
            int index = eventData.pointerEnter.GetComponent<StackArraySlot>().index;
            bool validDrop = true;

            
            // Check if all previous slots are filled
            for (int i = 0; i < index; i++)
            {
                if (!bools[i])
                {
                    validDrop = false;
                    audiosource1.Play();
                    
                    break;
                }
            }

            if (validDrop)
            {
                isDroppedInZone = true;
                StackArrayManager.Instance.AddElementToArray(index);
            }
            else
            {
                // Reset position if drop is not valid
                Debug.Log("Cant build stack on empty value");
                rectTransform.anchoredPosition = originalPosition;
            }
        }
        else
        {
            Debug.Log("Cant build stack on empty value");
            rectTransform.anchoredPosition = originalPosition;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition;
        Debug.Log("OnPointerDown");
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
    }
}