using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSellItemData : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Text name;
    [SerializeField] Text cost;
    [SerializeField] Button btn;
    Enemy enemy;

    public void SetData(string uid,string enemyID,CoinController coinController)
    {
        enemy = DataSingleton.Instance.GetEnemy(enemyID);
        image.sprite = Resources.Load<Sprite>(enemy.imagePath);
        name.text = enemy.name;
        cost.text = "판매가 " + enemy.cost.ToString();
        btn.onClick.AddListener(()=> {
            sound_single.Instance.PlayCoin();
            bool check = DataSingleton.Instance.SellEnemy(uid);
            if(check)
                coinController.SetCoinPlus(enemy.cost);
            Destroy(gameObject);
        });
    }
    public void OnClickSaleButton()
    {
        int playercoin = DataSingleton.Instance.PlayerCoin();
        playercoin += enemy.cost;
    }
}
