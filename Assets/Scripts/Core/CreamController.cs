using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreamController : Singleton<CreamController>
{
    [SerializeField] Image acne;
    [SerializeField] float smooth;
    [SerializeField] Animator animatorCream;
    private bool isAcne = true;
    private float acneAlpha = 1f;
    private void Update()
    {
        if (isAcne)
           return;
        else
        {
            if (acne.color.a > 0)
            {
                acneAlpha -= 0.1f * smooth;
                acne.color = new Color(1,1,1,acneAlpha);
            }
            else
            {

                isAcne = true;
                animatorCream.PlayInFixedTime("end_cream");
            }
               
        }

    }

    public void ClearCream()
    {
        acne.color = new Color(1, 1, 1, 1);
    }

    public void CreamOn()
    {
        if (acne.color.a != 0)
            isAcne = false;
        else
            return;
    }

}
