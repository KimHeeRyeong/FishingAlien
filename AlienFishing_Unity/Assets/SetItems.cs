using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SetItems : MonoBehaviour
{
    public GameObject itemPref;
    public SetPanelData setPanelData;
    // Start is called before the first frame update
    
    List<Item>[] items = new List<Item>[3]; //items[선택한 서브메뉴][아이템 번호]
    private void Awake()
    {
        string strBait = Resources.Load<TextAsset>("ItemData/ItemBait").ToString();
        List<Bait> baits = JsonUtility.FromJson<Baits>(strBait).bait;
        items[0] = baits.Cast<Item>().ToList();

        string strEquip = Resources.Load<TextAsset>("ItemData/ItemEquip").ToString();
        List<Equip> equips = JsonUtility.FromJson<Equips>(strEquip).equip;
        items[1] = equips.Cast<Item>().ToList();

        string strSing = Resources.Load<TextAsset>("ItemData/ItemSingleUse").ToString();
        List<SingleUse> singleUses = JsonUtility.FromJson<SingleUses>(strSing).singleUse;
        items[2] = singleUses.Cast<Item>().ToList();

        int maxCnt = baits.Count>equips.Count?baits.Count:equips.Count;
        maxCnt = singleUses.Count > maxCnt ? singleUses.Count : maxCnt;
        for(int i = 0; i < maxCnt; i++)
        {
            GameObject ins = Instantiate(itemPref, gameObject.transform);
            ins.SetActive(false);
        }
    }
    public void SetItemsToSelectSubMenu(int select) {
        int prefabCnt = transform.childCount;
        int itemCnt = items[select].Count;

        for(int i = 0; i < prefabCnt; i++)
        {
            GameObject item = transform.GetChild(i).gameObject;
            if (i < itemCnt)
            {
                Image image = item.GetComponent<Image>();
                image.sprite = Resources.Load<Sprite>(items[select][i].imagePath);

                int index = i;
                Button button = item.GetComponent<Button>();
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => setPanelData.SetData(items[select][index]));

                item.SetActive(true);
            }else if(item.activeSelf==true)
            {
                item.SetActive(false);
            }
        }
    }
}
