using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EyeshadowController : Singleton<EyeshadowController>
{
    [SerializeField] Image eyeshadowImage;
    [SerializeField] Sprite[] eyeshadowPool;
    [SerializeField] float smooth;
    [SerializeField] Animator animatorEyeshadow;
    private float eyeshadowAlpha;
    private bool eyeshadowOn = false;
    private int eyeshadowNumber;

    public void setEyeshadowNumber(int num)
    {
        eyeshadowNumber = num;
    }
    public void ChangeEyeshadow()
    {
        eyeshadowAlpha = 0;
        eyeshadowImage.color = new Color(1, 1, 1, eyeshadowAlpha);
        eyeshadowImage.sprite = eyeshadowPool[eyeshadowNumber];
        eyeshadowOn = true;
    }

    public void ClearEyeshadow()
    {
        eyeshadowImage.color = new Color(1, 1, 1, 0);
    }
    void Update()
    {
        if (!eyeshadowOn)
            return;
        else
        {
            if(eyeshadowAlpha < 1)
            {
                eyeshadowAlpha += 0.1f * smooth;
                eyeshadowImage.color = new Color(1, 1, 1, eyeshadowAlpha);
            }
            else 
            {
                eyeshadowOn = false;
                animatorEyeshadow.PlayInFixedTime("end");
            }
             
        }
    }
}
