using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volume_man
{
    private static volume_man instance;
    public float master_v = 100;

    public static volume_man getinstace()
    {
        if (instance == null)
        {
            instance = new volume_man();
        }        
        return instance;
    }
}
