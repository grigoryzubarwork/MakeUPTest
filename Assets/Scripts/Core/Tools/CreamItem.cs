using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreamItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    [SerializeField] Animator animatorCream;
    private bool ifFaceZone;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetAnimtionState()
    {
        animatorCream.PlayInFixedTime("start_cream");
    }

    public void ProcessDone()
    {
        CreamController.Instance.CreamOn();
    }

    public void SetDragable()
    {
        animatorCream.enabled = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
      
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (ifFaceZone)
        {
            animatorCream.enabled = true;
            animatorCream.PlayInFixedTime("process_cream");
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("faceZone"))
            ifFaceZone = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("faceZone"))
            ifFaceZone = false;
    }

}
