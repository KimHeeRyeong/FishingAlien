using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//json 데이터 사용
public class BookSCR : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnEnable() //켜질 때마다 스크롤바 맨위로 초기화
    {
        this.GetComponent<ScrollRect>().verticalScrollbar.value = 1;
    }
}