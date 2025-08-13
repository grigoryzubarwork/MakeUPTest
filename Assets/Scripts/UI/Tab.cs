using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tab : MonoBehaviour
{
    [SerializeField] GameObject activeTab;
    [SerializeField] GameObject inactiveTab;

    public void setActiveTab()
    {
        activeTab.SetActive(true);
        inactiveTab.SetActive(false);
    }

    public void setInactiveTab()
    {
        activeTab.SetActive(false);
        inactiveTab.SetActive(true);
    }
}
