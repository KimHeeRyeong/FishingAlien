using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPanelData : MonoBehaviour
{
    public Text explain;
    public Text cost;
    public Text itemName;
    public Image img;
    public void SetData(Item itemData) {
        explain.text = itemData.explain;
        cost.text = "가격 : " + itemData.cost.ToString();
        itemName.text = itemData.name;
        img.sprite = Resources.Load<Sprite>(itemData.imagePath);
    }
}
