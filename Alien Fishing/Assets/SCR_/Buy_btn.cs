using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Buy_btn : MonoBehaviour
{
    int buy;

    public CoinController playerSCR;

    public Button Buy_1_btn;
    public Button Buy_2_btn;

    private void Update()
    {       
        buy_btn_on();
    }
    public void Buy(int a)
    {
        sound_single.Instance.PlayCoin();
        playerSCR.SetCoinReduce(a);
    }    
    public void AddBait(string uid)
    {
        DataSingleton.Instance.BuyBait(uid);
    }
    void buy_btn_on()
    {
        if (playerSCR.GetCoin() < 100)
        {
            Buy_1_btn.interactable = false;
            Buy_2_btn.interactable = false;
        }
        else if (playerSCR.GetCoin() < 500)
        {
            Buy_1_btn.interactable = true;
            Buy_2_btn.interactable = false;
        }
        else
        {
            Buy_1_btn.interactable = true;
            Buy_2_btn.interactable = true;
        }
    }
}