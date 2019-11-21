using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionSCR : MonoBehaviour
{
    [SerializeField] EnemyCollection Enemy;
    [SerializeField] EnemyDetailCollection EnemyDetail;

    public Button Left = null;
    public Button Right = null;

    GameObject NowContent = null; //현재 보는 콘텐츠창

    public GameObject[] ContentArray;

    int i = 0;

    private void Awake()
    {
        Enemy.enemy.ToString();
        EnemyDetail.enemyDetail.ToString();
    }

    void Start()
    {
        NowContent = ContentArray[0];
        NowContent.SetActive(true);
    }

    void Update()
    {
        if(NowContent==ContentArray[0])
        {
            Left.enabled = false;
            Left.image.enabled = false;
        }
        else if(NowContent==ContentArray[5])
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

        NowContent.SetActive(true);
    }

    private void OnEnable()
    {
        i = 0;
        NowContent = ContentArray[0];
    }

    private void OnDisable()
    {
        i = 0;
        NowContent.SetActive(false);
        Left.enabled = true;
        Right.enabled = true;
        Left.image.enabled = true;
        Right.image.enabled = true;
    }

    public void OnClickLeft()
    {
        if(NowContent!=ContentArray[0])
        {
            ContentArray[i] = NowContent;
            ContentArray[i].SetActive(false);
            i--;
            NowContent = ContentArray[i];
        }
        
    }

    public void OnClickRight()
    {
        if(NowContent!=ContentArray[5])
        {
            ContentArray[i] = NowContent;
            ContentArray[i].SetActive(false);
            i++;
            NowContent = ContentArray[i];
        }        
    }
}