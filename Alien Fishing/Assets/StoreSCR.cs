using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreSCR : MonoBehaviour
{
    public GameObject BuyView = null;
    public GameObject SaleView = null;
    public GameObject IndexView = null;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClickBuyViewButton()
    {
        IndexView.SetActive(false);
        SaleView.SetActive(false);
        BuyView.SetActive(true);
    }

    public void OnClickSaleViewButton()
    {
        IndexView.SetActive(false);
        BuyView.SetActive(false);
        SaleView.SetActive(true);
    }
}
