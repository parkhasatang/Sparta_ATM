using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject SelectBtn;
    public GameObject OpenWithDrawPanel;
    public GameObject OpenTransferPanel;
    public void WithDraw()
    {
        SelectBtn.SetActive(false);
        OpenWithDrawPanel.SetActive(true);
    }

    public void Transfer()
    {
        SelectBtn.SetActive(false);
        OpenTransferPanel.SetActive(true);
    }

    public void BackSpaceBtn()
    {
        if (OpenWithDrawPanel.activeSelf)
        {
            OpenWithDrawPanel.SetActive(false);
        }
        else if (OpenTransferPanel.activeSelf)
        {
            OpenTransferPanel.SetActive(false) ;
        }
        SelectBtn.SetActive(true);
    }
}
