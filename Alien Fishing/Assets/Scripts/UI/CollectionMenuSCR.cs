using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionMenuSCR : MonoBehaviour
{
    public GameObject CollectionOpenKey = null;
    public GameObject Screen_Collection = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            Debug.Log("Collection Enter");
            Screen_Collection.SetActive(true);
            if (GameSingleton.Instance.GetUIState() == GameSingleton.UIState.NONE)
                CollectionOpenKey.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player")
            && GameSingleton.Instance.GetUIState() == GameSingleton.UIState.NONE)
        {
            if (!CollectionOpenKey.activeSelf)
                CollectionOpenKey.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collection Exit");
            CollectionOpenKey.SetActive(false);
            Screen_Collection.SetActive(false);
        }
    }
}