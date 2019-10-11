using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreSCR : MonoBehaviour
{
    public ScrollRect StoreScrollView = null;

    bool storecheck = false;

    void Start()
    {

    }

    void Update()
    {
        if (storecheck == false && Input.GetKeyDown(KeyCode.Z))
            OnStoreOpen();

        else if (storecheck == true && Input.GetKeyDown(KeyCode.Z))
            OnStoreExit();
    }

    private void OnEnable() //켜질 때마다 스크롤바 맨위로 초기화
    {
        StoreScrollView.verticalScrollbar.value = 1;
    }

    public void OnStoreOpen()
    {

        this.gameObject.SetActive(true);
        storecheck = true;

    }

    public void OnStoreExit()
    {

        this.gameObject.SetActive(false);
        storecheck = false;

    }
}
