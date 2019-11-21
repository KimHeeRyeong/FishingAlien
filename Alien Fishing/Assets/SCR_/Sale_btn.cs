using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sale_btn : MonoBehaviour
{

    public CoinController playerSCR; 
    
    public void Sale(int a)
    {
        sound_single.Instance.PlayCoin();
        playerSCR.SetCoinPlus(a);
    }
}
