using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBtnController : SelectOneInBtns
{
    SelectOneInBtns selectOneInBtns;
    private void Start()
    {
        int iMenuSelect = ShopManager.Instance.GetSelectMenu();
        bool addBtnLis = BtnAddListener(iMenuSelect);
        if (!addBtnLis)
        {
            Debug.Log(this.gameObject.name + ":BtnAddListener() error! **please check ShopManager->select_menu value**");
        }
    }
}
