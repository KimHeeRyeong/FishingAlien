﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class actionMenu : MonoBehaviour
{
    [MenuItem("MyMenu/Do Something")]
    static void DoSomething()
    {
        Debug.Log("Doing Something...");
    }
    
}
