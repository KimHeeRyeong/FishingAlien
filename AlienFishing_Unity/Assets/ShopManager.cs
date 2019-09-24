using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private static ShopManager instance = null;
    public static ShopManager Instance { get => instance; }

    int select_subMenu = 0;

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
    
    public void ChangeSubMenu(int select)
    {
        select_subMenu = select;
    }
}
