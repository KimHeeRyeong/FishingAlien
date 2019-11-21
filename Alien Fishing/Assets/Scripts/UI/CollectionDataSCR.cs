using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionDataSCR : MonoBehaviour
{
    public Button Left = null;
    public Button Right = null;

    GameObject NowContent = null; //현재 보는 콘텐츠창
    
    GameObject[] ContentArray = null;
    [SerializeField] GameObject viewPort;
    [SerializeField] GameObject collectionItem;

    int index = 0;
    int contentCnt = 0;
    private void Start()
    {
        EnemyDetail[] enemyDetails = DataSingleton.Instance.GetEnemyDetails();
        contentCnt = enemyDetails.Length;
        ContentArray = new GameObject[contentCnt];
        for(int i = 0; i < contentCnt; i++)
        {
            //data setting
            Enemy enemy = DataSingleton.Instance.GetEnemy(enemyDetails[i].enemyID);
            GameObject obj = Instantiate(collectionItem, viewPort.transform);
            obj.GetComponent<CollectionDataSetting>().Initialize(enemyDetails[i], enemy);
            obj.SetActive(false);
            ContentArray[i] = obj;
        }
    }
    void Update()
    {
        if (index == 0)
        {
            Left.enabled = false;
            Left.image.enabled = false;
        }
        else if (index == contentCnt-1)
        {
            Right.enabled = false;
            Right.image.enabled = false;
        }
        else
        {
            Left.enabled = true;
            Right.enabled = true;
            Left.image.enabled = true;
            Right.image.enabled = true;
        }

        NowContent = ContentArray[index];
        NowContent.SetActive(true);
    }

    private void OnEnable()
    {
        index = 0;
        Debug.Log(contentCnt);
        for (int j = 0; j < contentCnt; j++)
        {
            CollectionDataSetting dataSetting = ContentArray[j].GetComponent<CollectionDataSetting>();

            string UID = dataSetting.GetUID();
            bool gotplayer = DataSingleton.Instance.DetailGotPlayer(UID);
            dataSetting.SetGotPlayer(gotplayer);
        }
    }

    private void OnDisable()
    {
        if(NowContent!=null)
            NowContent.SetActive(false);
        Left.enabled = true;
        Right.enabled = true;
        Left.image.enabled = true;
        Right.image.enabled = true;
    }

    public void OnClickLeft()
    {
        sound_single.Instance.PlayClick();
        if (index != 0)
        {
            NowContent.SetActive(false);
            index--;
        }
    }

    public void OnClickRight()
    {
        sound_single.Instance.PlayClick();
        if (index != contentCnt-1)
        {
            NowContent.SetActive(false);
            index++;
        }
    }
}