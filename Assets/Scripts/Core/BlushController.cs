using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BlushController : Singleton<BlushController>
{
    [SerializeField] Image blushImage;
    [SerializeField] Sprite[] blushPool;
    [SerializeField] float smooth;
    [SerializeField] Animator animatorBlush;
    private bool blushOn = false;
    private float blushAlpha;
    private int blushNumber;
  
    public void SetBlushNumber(int num)
    {
        blushNumber = num;
    }

    public void ChangeBlush()
    {
        blushAlpha = 0;
        blushImage.color = new Color(1, 1, 1, blushAlpha);
        blushImage.sprite = blushPool[blushNumber];
        blushOn = true;
    }

    public void ClearBlush()
    {
        blushImage.color = new Color(1, 1, 1, 0);
    }
    void Update()
    {
        if (!blushOn)
            return;
        else
        {
            if(blushAlpha < 1)
            {
                blushAlpha += 0.1f * smooth;
                blushImage.color = new Color(1, 1, 1, blushAlpha);
            }
            else
            {
                blushOn = false;
                animatorBlush.PlayInFixedTime("end");
            }
        }
    }
}
