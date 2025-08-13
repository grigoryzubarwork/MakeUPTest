using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EyeshadowBrushItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    [SerializeField] Animator animatorEyeshadow;
    [SerializeField] Image brushTip;
    [SerializeField] Color[] eyeshadowColorsPool;
    private bool ifFaceZone;
    private int eyeshadowColorNumber;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void StartInteraction(int num)
    {
        animatorEyeshadow.enabled = true;
        eyeshadowColorNumber = num;
        animatorEyeshadow.PlayInFixedTime("start");
    }
    public void SetItemColor()
    {
        brushTip.color = eyeshadowColorsPool[eyeshadowColorNumber];
    }

    public void SetDragablle()
    {
        animatorEyeshadow.enabled = false;
    }

    public void EyeshadowOn()
    {
        EyeshadowController.Instance.ChangeEyeshadow();
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
            animatorEyeshadow.enabled = true;
            animatorEyeshadow.PlayInFixedTime("process");
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
