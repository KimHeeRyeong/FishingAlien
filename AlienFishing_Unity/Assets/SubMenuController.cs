using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMenuController : SelectOneInBtns
{
    // Start is called before the first frame update
    void Start()
    {
        int iSubSelect = ShopManager.Instance.GetSelectSub();
        bool addBtnLis = BtnAddListener(iSubSelect);
        if (!addBtnLis)
        {
            Debug.Log(this.gameObject.name + ":BtnAddListener() error! **please check ShopManager->select_subMenu value**");
        }

    }
}
