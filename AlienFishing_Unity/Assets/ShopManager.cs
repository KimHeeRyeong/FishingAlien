using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private static ShopManager instance = null;
    public static ShopManager Instance { get => instance; }

    int select_menu = 2; 
    int select_subMenu = 0;
    int select_item = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

    }
    private void OnDestroy()
    {
        instance = null;   
    }
    public int GetSelectItem()
    {
        return select_item;
    }
    public int GetSelectSub() {
        return select_subMenu;
    }
    public int GetSelectMenu() {
        return select_menu;
    }
}
