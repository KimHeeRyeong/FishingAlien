using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreDataSCR : MonoBehaviour
{
    [SerializeField] GameObject GetEnemyPrefab;
    [SerializeField] CoinController coin;

    List<PlayerEnemy> playerEnemies = null;

    public GameObject IndexView = null;
    public GameObject BuyView = null;
    public GameObject SaleView = null;

    public GameObject[] StoreBaitArray;


    public GameObject SaleViewContent = null;

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            string UID = StoreBaitArray[i].GetComponent<StoreDataSetting>().UIDCODE;
            string baitID = StoreBaitArray[i].GetComponent<StoreDataSetting>().baitID;

            string image = DataSingleton.Instance.BaitImage(UID);
            string name = DataSingleton.Instance.BaitName(baitID);
            int cost = DataSingleton.Instance.BaitCost(UID);
            string data = DataSingleton.Instance.BaitDetailData(UID);
            int pow = DataSingleton.Instance.BaitPower(baitID);
            int spd = DataSingleton.Instance.BaitSpeed(baitID);
            int all = DataSingleton.Instance.BaitAllure(baitID);

            StoreBaitArray[i].transform.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(image);

            PlayerBait playerBait = DataSingleton.Instance.FindPlayerBaitFromBait(baitID);
            if (playerBait == null)
                StoreBaitArray[i].transform.GetComponentInChildren<Text>().text = "0개";
            else
                StoreBaitArray[i].transform.GetComponentInChildren<Text>().text = playerBait.count.ToString() + "개";

            StoreBaitArray[i].transform.GetChild(1).GetComponent<Text>().text = name;
            StoreBaitArray[i].transform.GetChild(2).GetComponent<Text>().text = "가격 " + cost;
            StoreBaitArray[i].transform.GetChild(3).GetComponent<Text>().text = data;
            StoreBaitArray[i].transform.GetChild(4).GetComponent<Text>().text = "힘" + pow + " 속도" + spd + " 매력도" + all;

            int coinCount = 0;
            string uid = "01000";
            if (i == 1)
            {
                coinCount = 100;
                uid = "01001";
            }
            else if (i == 2)
            {
                coinCount = 500;
                uid = "01002";
            }

            StoreBaitArray[i].GetComponentInChildren<Button>().onClick.AddListener(() => {
                sound_single.Instance.PlayCoin();
                coin.SetCoinReduce(coinCount);
            });

            Transform tra = StoreBaitArray[i].transform;

            StoreBaitArray[i].GetComponentInChildren<Button>().onClick.AddListener(() => {
                DataSingleton.Instance.BuyBait(uid);
                PlayerBait baitPlayer = DataSingleton.Instance.FindPlayerBaitFromBait(uid);
                if (baitPlayer == null)
                {
                    Debug.Log("null");
                    tra.GetComponentInChildren<Text>().text = "0개";
                }
                else
                {
                    Debug.Log(baitPlayer.count);
                    tra.GetComponentInChildren<Text>().text = baitPlayer.count.ToString() + "개";
                }
            });
        }
    }

    public void Buy(int a)
    {
        sound_single.Instance.PlayCoin();
        coin.SetCoinReduce(a);
    }
    public void AddBait(string uid, GameObject obj)
    {
        DataSingleton.Instance.BuyBait(uid);

        PlayerBait playerBait = DataSingleton.Instance.FindPlayerBaitFromBait(uid);

        if (playerBait == null)
            transform.GetComponentInChildren<Text>().text = "0개";
        else
            transform.GetComponentInChildren<Text>().text = playerBait.count.ToString() + "개";
    }
    void Update()
    {
        if (SaleView.activeSelf == false)
        {
            int cnt = SaleViewContent.transform.childCount;
            for (int i = 0; i < cnt; i++)
            {
                Destroy(SaleViewContent.transform.GetChild(0).gameObject);
            }
            playerEnemies = null;
        }
    }

    public void OnClickBuyViewButton()
    {
        sound_single.Instance.PlayClick();
        IndexView.SetActive(false);
        BuyView.SetActive(true);
        SaleView.SetActive(false);
        BuyView.GetComponent<ScrollRect>().verticalScrollbar.value = 1;
    }

    public void OnClickSaleViewButton()
    {
        sound_single.Instance.PlayClick();
        IndexView.SetActive(false);
        BuyView.SetActive(false);
        SaleView.SetActive(true);
        SaleView.GetComponent<ScrollRect>().verticalScrollbar.value = 1;
        if (playerEnemies == null)
        {
            playerEnemies = DataSingleton.Instance.GetPlayerEnemy();
            int cnt = playerEnemies.Count;
            Debug.Log(cnt);
            for (int i = 0; i < cnt; i++)
            {
                GameObject obj = Instantiate(GetEnemyPrefab, gameObject.transform);
                obj.transform.parent = SaleViewContent.transform;
                obj.transform.localScale = new Vector3(1f, 1f, 1f);
                obj.GetComponent<SetSellItemData>().SetData(playerEnemies[i].UIDCODE, playerEnemies[i].enemyID, coin);
            }
        }
    }

    private void OnEnable()
    {
        IndexView.SetActive(true);
        BuyView.SetActive(false);
        SaleView.SetActive(false);
    }
}