using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreMenuSCR : MonoBehaviour//active openkey
{
    public GameObject StoreOpenKey = null;
    public GameObject Screen_Store = null;

    void Update()
    {
        Store();
    }

    //상점 onoff
    public void Store()
    {   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Store Enter");
            Screen_Store.SetActive(true);

            if (GameSingleton.Instance.GetUIState() == GameSingleton.UIState.NONE)
                StoreOpenKey.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player")
            && GameSingleton.Instance.GetUIState() == GameSingleton.UIState.NONE)
        {
            Debug.Log("Store stay");
            if (!StoreOpenKey.activeSelf)
                StoreOpenKey.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Store Exit");
            StoreOpenKey.SetActive(false);
            Screen_Store.SetActive(false);
        }
    }
}