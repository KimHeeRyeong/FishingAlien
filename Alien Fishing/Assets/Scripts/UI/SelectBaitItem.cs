using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBaitItem : MonoBehaviour
{
    [SerializeField] Text count;
    [SerializeField] Image image;
    string baitUID;
    string playerbaitUID;
    public void Initialize(string imagePath, string baitUID) {
        image.sprite = Resources.Load<Sprite>(imagePath);
        this.baitUID = baitUID;
    }
    public void SetValue(int count, string playerbaitUID) {
        this.count.text = count.ToString();
        this.playerbaitUID = playerbaitUID;
    }
    public string GetUID() {
        return baitUID;
    }
    public string GetPlayerBaitUID() {
        return playerbaitUID;
    }
}
