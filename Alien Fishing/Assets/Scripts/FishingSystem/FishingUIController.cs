using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingUIController : MonoBehaviour
{
    [SerializeField] GameObject selectBaitItem;
    [SerializeField] GameObject itemsParent;
    [Space()]
    [SerializeField] GameObject selectUI;
    [SerializeField] GameObject fishingStartUI;
    [SerializeField] GameObject dontFishingUI;

    SelectBaitItem[] items;
    RectTransform rectTransform;
    int itemCnt = 0;
    List<int> canSelectIndex = new List<int>();
    int activeCnt = -1;//선택 가능 미끼 없음
    int select = -1;
    // Start is called before the first frame update
    void Start()
    {
        //instantiate items 
        rectTransform = itemsParent.transform.GetComponent<RectTransform>();

        BaitDetail[] baitDetails = DataSingleton.Instance.GetBaitDetail();

        if (baitDetails == null || baitDetails.Length == 0)
            return;
        itemCnt = baitDetails.Length;
        items = new SelectBaitItem[itemCnt];
        for (int i = 0; i < itemCnt; i++)
        {
            GameObject obj = Instantiate(selectBaitItem, itemsParent.transform);
            items[i] = obj.GetComponent<SelectBaitItem>();
            items[i].Initialize(baitDetails[i].imagePath, baitDetails[i].baitID);
            obj.SetActive(false);
        }
        gameObject.SetActive(false);
    }

    void CantFishing() {
        fishingStartUI.SetActive(false);
        selectUI.SetActive(false);

        dontFishingUI.SetActive(true);
    }

    public void CanFishing(bool active) {
        selectUI.SetActive(true);
        fishingStartUI.SetActive(active);
        dontFishingUI.SetActive(false);
    }

    public bool Active() //active SelectBait
    {

        activeCnt = -1;
        select = -1;

        //load playerBait data
        List<PlayerBait> playerBaits = DataSingleton.Instance.GetPlayerBaits();
        if (playerBaits.Count == 0)
        {
            CantFishing();
            return false;
        }

        canSelectIndex.Clear();
        string playerwearBaitUID = DataSingleton.Instance.GetPlayerWearBait();

        for (int i = 0; i < itemCnt; i++)
        {
            string UID = items[i].GetUID();
            PlayerBait playerBait = playerBaits.Find(x => x.baitID == UID);
            
            if (playerBait != null&&playerBait.count>0)
            {
                activeCnt++;
                canSelectIndex.Add(i);

                //player가 착용한 bait인 경우
                if (playerwearBaitUID == playerBait.UIDCODE)
                {
                    select = activeCnt;
                    rectTransform.localPosition = new Vector3(-select * 220,
                        rectTransform.localPosition.y
                        , rectTransform.localPosition.z);
                }
                items[i].SetValue(playerBait.count, playerBait.UIDCODE);
                items[i].gameObject.SetActive(true);
            }
            else
            {
                items[i].gameObject.SetActive(false);
            }
        }

        //active가능한 미끼가 없는경우
        if (activeCnt == -1)
        {
            CantFishing();
            return false;
        }

        //선택된 미끼가 없는 경우 0번 미끼 선택
        if (select == -1)
        {
            int index = canSelectIndex[0];
            DataSingleton.Instance.SetPlayerWearBait(items[index].GetPlayerBaitUID());
            select = 0;
        }

        CanFishing(false);
        return true;
    }
    // Update is called once per frame
    
    public void SelectR()
    {
        sound_single.Instance.PlayClick();
        if (activeCnt <= 0)
            return;

        if (select < activeCnt)
        {
            rectTransform.localPosition -= Vector3.right * 220;
            select++;
            int index = canSelectIndex[select];
            Debug.Log(items[index].GetPlayerBaitUID());
            DataSingleton.Instance.SetPlayerWearBait(items[index].GetPlayerBaitUID());
        }
    }
    public void SelectL()
    {
        sound_single.Instance.PlayClick();
        if (activeCnt <= 0)
            return;

        if (select > 0)
        {
            rectTransform.localPosition += Vector3.right * 220;
            select--;
            int index = canSelectIndex[select];
            DataSingleton.Instance.SetPlayerWearBait(items[index].GetPlayerBaitUID());
        }
    }
}
