using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionDataSetting : MonoBehaviour
{
    string UIDCODE = null;
    string enemyID = null;
    [SerializeField] Image enemyImage = null;
    [SerializeField] GameObject enemyName = null;
    [SerializeField] GameObject enemyDetail = null;
    [Space()]
    [SerializeField] GameObject noname = null;
    [SerializeField] GameObject noDetail = null;

    public void Initialize(EnemyDetail detailData,Enemy enemy)
    {
        UIDCODE = detailData.UIDCODE;
        enemyID = detailData.enemyID;
        enemyImage.sprite = Resources.Load<Sprite>(enemy.imagePath);
        enemyName.GetComponent<Text>().text = enemy.name;
        enemyDetail.GetComponent<Text>().text = detailData.data;
    }
    public string GetUID() {
        return UIDCODE;
    }
    public void SetGotPlayer(bool gotPlayer) {
        if (gotPlayer)
        {
            enemyImage.color = Color.white;

            noname.SetActive(false);
            noDetail.SetActive(false);

            enemyName.SetActive(true);
            enemyDetail.SetActive(true);
        }
        else
        {
            enemyImage.color = Color.black;

            noname.SetActive(true);
            noDetail.SetActive(true);

            enemyName.SetActive(false);
            enemyDetail.SetActive(false);
        }
    }

}
