using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectOneInBtns : MonoBehaviour
{
    [SerializeField]
    Button[] btns = null;

    Animator[] animators = null;
    int btnCnt = 0;
    int selet = 0;//현재 선택된 버튼
    void Start()
    {
        //init animators
        btnCnt = btns.Length;
        animators = new Animator[btnCnt];
        for (int i = 0; i < btnCnt; i++)
        {
            animators[i] = btns[i].gameObject.GetComponent<Animator>();
        }

        for (int i = 0; i < btnCnt; i++)
        {
            int index = i;
            btns[i].onClick.AddListener(() => BtnClick(index));
        }

        animators[selet].SetTrigger("Select");
    }

    void BtnClick(int i)
    {
        if (selet != i)
        {
            animators[selet].SetTrigger("Deselect");
            animators[i].SetTrigger("Select");
            selet = i;
        }
    }
}
