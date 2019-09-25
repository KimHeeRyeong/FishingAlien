using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBtnController : SelectOneInBtns
{
    public SetMainContent setMainContent;
    private void Start()
    {
        int iMenuSelect = ShopManager.Instance.GetSelectMenu();
        bool addBtnLis = BtnAddListener(iMenuSelect);
        if (!addBtnLis)
        {
            Debug.Log(this.gameObject.name + ":BtnAddListener() error! **please check ShopManager->select_menu value**");
        }
        MenuBtnConnectContent();
        setMainContent.SetContent(iMenuSelect);
    }
    void MenuBtnConnectContent()
    {
        for(int i = 0; i < btnCnt; i++)
        {
            int index = i;
            btns[i].onClick.AddListener(() => setMainContent.SetContent(index));
        }
    }
}