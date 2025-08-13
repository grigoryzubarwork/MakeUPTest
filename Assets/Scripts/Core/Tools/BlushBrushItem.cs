using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlushBrushItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    [SerializeField] Color[] colorsPool;
    [SerializeField] Image brushTip;
    [SerializeField] Animator animatorBlush;
    private bool ifFaceZone;
    private int itemColorNumber;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void StartInteraction(int num)
    {
        animatorBlush.enabled = true;
        itemColorNumber = num;
        animatorBlush.PlayInFixedTime("start");
    }
    
    public void SetColor()
    {
        brushTip.color = colorsPool[itemColorNumber];
    }

    public void SetDragable()
    {
        animatorBlush.enabled = false;
    }

    public void BlushOn()
    {
        BlushController.Instance.ChangeBlush();
        brushTip.color = new Color(1, 1, 1, 1);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (ifFaceZone)
        {
            animatorBlush.enabled = true;
            animatorBlush.PlayInFixedTime("process");
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
