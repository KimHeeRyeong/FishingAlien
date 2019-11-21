using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_single
{
    static Menu_single instance = null;

    public enum Menu_enum
    {
        NONE,
        MENU,
        OTHER,
        FISHING
    }

    static public Menu_single get_instance()
    {
        if (instance == null)
        {
            instance = new Menu_single();       
        }
        return instance;
    }

    Menu_enum ME = Menu_enum.NONE;

    public Menu_enum get_ME()
    {
        return ME;
    }
    public void set_ME(Menu_enum SME)
    {
        ME = SME;
    }
}
