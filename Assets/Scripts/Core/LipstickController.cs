using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LipstickController : Singleton<LipstickController>
{
    [SerializeField] Image lipstickImage;
    [SerializeField] Sprite[] lipstickPool;
    [SerializeField] float smooth;
    [SerializeField] Animator animatorLipstick;
    private float lipstickAlpha;
    private bool lipstickOn = false;
    private int lipstickNumber;

    public void setLipstickNumber(int num)
    {
        lipstickNumber = num;
    }

    public void ChangeLipstick()
    {
        lipstickAlpha = 0;
        lipstickImage.color = new Color(1, 1, 1, lipstickAlpha);
        lipstickImage.sprite = lipstickPool[lipstickNumber];
        lipstickOn = true;
    }

    public void ClearLipstick()
    {
        lipstickImage.color = new Color(1, 1, 1, 0);
    }
    void Update()
    {
        if (!lipstickOn)
            return;
        else
        {
            if(lipstickAlpha < 1)
            {
                lipstickAlpha += 0.1f * smooth;
                lipstickImage.color = new Color(1, 1, 1, lipstickAlpha);
            }
            else
            {
                lipstickOn = false;
                animatorLipstick.PlayInFixedTime("end");
            }
        }
    }
}
