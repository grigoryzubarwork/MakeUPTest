using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabsController : MonoBehaviour
{
    [SerializeField] GameObject EyeshadowPage;
    [SerializeField] GameObject BlushPage;
    [SerializeField] GameObject LipstickPage;
    [SerializeField] Tab[] tabs;
    public void CloseAllPages()
    {
        EyeshadowPage.SetActive(false);
        BlushPage.SetActive(false);
        LipstickPage.SetActive(false);
        foreach(Tab tab in tabs)
        {
            tab.setInactiveTab();
        }
    }

    public void OpenPowderCream()
    {
        CloseAllPages();
        tabs[0].setActiveTab();
    }

    public void OpenEyeshadow()
    {
        CloseAllPages();
        EyeshadowPage.SetActive(true);
        tabs[3].setActiveTab();
    }

    public void OpenBlush()
    {
        CloseAllPages();
        BlushPage.SetActive(true);
        tabs[1].setActiveTab();
    }

    public void OpenLipstick()
    {
        CloseAllPages();
        LipstickPage.SetActive(true);
        tabs[2].setActiveTab();
    }
}
