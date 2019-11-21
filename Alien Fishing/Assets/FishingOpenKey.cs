using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingOpenKey : MonoBehaviour
{
    Text tx;
    [SerializeField]GameObject[] checkObjs;
    private void Awake()
    {
        tx = GetComponent<Text>();
        tx.enabled = false;
    }
    void Update()
    {
        int cnt = checkObjs.Length;
        bool check = false;
        for (int i = 0; i < cnt; i++)
        {
            if (checkObjs[i].activeSelf)
            {
                check = true;
                break;
            }
        }
        Debug.Log(check);
        if (GameSingleton.Instance.GetUIState() == GameSingleton.UIState.NONE && !check)
            tx.enabled = true;
        else
            tx.enabled = false;
    }
}
