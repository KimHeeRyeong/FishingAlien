using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    [SerializeField]Text Coin_text;
    [SerializeField]int coin_plus =0;
    private void Start()
    {
        coin_plus = DataSingleton.Instance.PlayerCoin();
        Coin_text.text = coin_plus.ToString() + " UC";
    }
    public void SetCoinPlus(int addCoin)
    {
        coin_plus += addCoin;
        Coin_text.text = coin_plus.ToString() + " UC";
        DataSingleton.Instance.SetPlayerCoin(coin_plus);
    }
    public void SetCoinReduce(int reduceCoin) {
        coin_plus -= reduceCoin;
        Coin_text.text = coin_plus.ToString() + " UC";
        DataSingleton.Instance.SetPlayerCoin(coin_plus);
    }
    public int GetCoin() {
        return coin_plus;
    }
}
