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
    List<Bait> baits = null;
    List<Equip> equips = null;
    List<SingleUse> singleUses = null;

    private void Awake()
    {
        string strBait = Resources.Load<TextAsset>("ItemData/ItemBait").ToString();
        baits = JsonUtility.FromJson<Baits>(strBait).bait;

        string strEquip = Resources.Load<TextAsset>("ItemData/ItemEquip").ToString();
        equips = JsonUtility.FromJson<Equips>(strEquip).equip;

        string strSing = Resources.Load<TextAsset>("ItemData/ItemSingleUse").ToString();
        singleUses = JsonUtility.FromJson<SingleUses>(strSing).singleUse;

        int maxCnt = baits.Count>equips.Count?baits.Count:equips.Count;
        maxCnt = singleUses.Count > maxCnt ? singleUses.Count : maxCnt;
        for(int i = 0; i < maxCnt; i++)
        {
            GameObject ins = Instantiate(itemPref, gameObject.transform);
            ins.SetActive(false);
        }
    }
    private void Start()
    {
        BaitClick();
    }
    public void BaitClick()
    {
        List<Item> items = baits.Cast<Item>().ToList();
        SetItemsToSelectSubMenu(items);
    }
    public void EquipClick() {
        List<Item> items = equips.Cast<Item>().ToList();
        SetItemsToSelectSubMenu(items);
    }
    public void SingleUseClick()
    {
        List<Item> items = singleUses.Cast<Item>().ToList();
        SetItemsToSelectSubMenu(items);
    }
    void SetItemsToSelectSubMenu(List<Item> items) {
        int prefabCnt = transform.childCount;
        int itemCnt = items.Count;

        for(int i = 0; i < prefabCnt; i++)
        {
            GameObject item = transform.GetChild(i).gameObject;
            if (i < itemCnt)
            {
                Image image = item.GetComponent<Image>();
                image.sprite = Resources.Load<Sprite>(items[i].imagePath);

                int index = i;
                Button button = item.GetComponent<Button>();
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => setPanelData.SetData(items[index]));

                item.SetActive(true);
            }else if(item.activeSelf==true)
            {
                item.SetActive(false);
            }
        }
    }
}
