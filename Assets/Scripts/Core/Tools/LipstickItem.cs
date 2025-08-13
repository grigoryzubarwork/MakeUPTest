using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LipstickItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    [SerializeField] Image lipstickImage;
    [SerializeField] Sprite[] lipstickPool;
    [SerializeField] Animator animatorLipstick;
    private bool ifFaceZone;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetItemColor(int num)
    {
        animatorLipstick.enabled = true;
        lipstickImage.enabled = true;
        lipstickImage.sprite = lipstickPool[num];
        animatorLipstick.PlayInFixedTime("start");
    }

    public void SetDragable()
    {
        animatorLipstick.enabled = false;
    }

    public void LipstickOn()
    {
        LipstickController.Instance.ChangeLipstick();
    }

    public void HideLipstick()
    {
        lipstickImage.enabled = false;
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
            animatorLipstick.enabled = true;
            animatorLipstick.PlayInFixedTime("process");
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
