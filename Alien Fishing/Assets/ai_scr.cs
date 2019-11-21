using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai_scr : MonoBehaviour
{
    public enum charStatus {       //인공지능의 동작 패턴의 종류를 열거형으로 설정한다.
        Study,//공부
        Drink,//물마시기
        Eat,//먹기
        Rest,//쉬기
        Sleep,//자기
    }

    public charStatus myStatus = 0;
    public int thirsty = 0;//목마름정도 = Drink의 트리거가 되는 변수
    public int hungry = 0;//배고픔 = Eat의 트리거
    public int tired = 0;//피로 = Rest의 트리거
    public int time = 0;//시간 = Sleep의 트리거

    void Start()
    {
        StartCoroutine(action());
    }
    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator action() {
        float timeDelay = 0;
        while (true)
        {
            time++;
            if (myStatus == charStatus.Study)
            {
                Debug.Log("공부를 합니다.");
                hungry++;
                thirsty++;
                tired++;
                timeDelay = 2;
            }
            else if (myStatus == charStatus.Drink)
            {
                Debug.Log("물을 마십니다.");
                thirsty = 0;
                timeDelay = 0.2f;
            }
            else if (myStatus == charStatus.Eat)
            {
                Debug.Log("식사를 합니다.");
                hungry = 0;
                thirsty = 0;
                timeDelay = 1;
            }
            else if (myStatus == charStatus.Rest)
            {
                Debug.Log("잠시 쉽니다.");
                tired -= 3;
                timeDelay = 0.5f;
            }
            else if (myStatus == charStatus.Sleep)
            {
                Debug.Log("잠을 잡니다.");
                tired = 0;
                hungry++;
                thirsty++;
                time = 0;
                timeDelay = 3;
            }

            if (time > 20)
            {
                myStatus = charStatus.Sleep;
            }
            else if (tired > 5)
            {
                myStatus = charStatus.Rest;
            }
            else if (hungry > 7)
            {
                myStatus = charStatus.Eat;
            }
            else if (thirsty > 4)
            {
                myStatus = charStatus.Drink;
            }
            else
            {
                myStatus = charStatus.Study;
            }

            yield return new WaitForSeconds(timeDelay);
        }
    }
}
