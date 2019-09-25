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
    int select = -1;//현재 선택된 버튼, -1==전체 선택 불가 상태
    
    protected bool BtnAddListener(int iselect)//init select
    {
        //init animators
        btnCnt = btns.Length;
        if (iselect >= btnCnt)
        {
            return false;//add listener 실패
        }
        animators = new Animator[btnCnt];
        for (int i = 0; i < btnCnt; i++) //get animator & 버튼 선택불가 상태로 초기화
        {
            animators[i] = btns[i].gameObject.GetComponent<Animator>();
            animators[i].SetTrigger("Deselect");
            btns[i].enabled = false;
        }

        for (int i = 0; i < btnCnt; i++)
        {
            int index = i;
            btns[i].onClick.AddListener(() => BtnClick(index));
        }
        
        BtnClick(iselect);
        return true;
    }
    protected void BtnClick(int i)
    {
        if (select != i)
        {
            if (select == -1) {
                for(int ibtn = 0; ibtn < btnCnt; ibtn++)
                {
                    btns[ibtn].enabled = true;
                }
                animators[i].SetTrigger("Select");
                btns[i].enabled = false;
            } else if (i == -1) {
                for (int ibtn = 0; ibtn < btnCnt; ibtn++)
                {
                    btns[ibtn].enabled = false;
                }
                animators[select].SetTrigger("Deselect");
            } else
            {
                animators[select].SetTrigger("Deselect");
                animators[i].SetTrigger("Select");
                btns[i].enabled = false;
                btns[select].enabled = true;
            }
            select = i;
        }
    }
}
