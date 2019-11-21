using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaitSelectSCR : MonoBehaviour
{
    public GameObject BaitSelectObject = null;
    public GameObject[] BaitArray;

    public GameObject HaveBait = null;


    void Start()
    {
        BaitArray = new GameObject[5];
    

        GameObject Bait0 = Instantiate(HaveBait, new Vector3(0, -0.5f, 3), Quaternion.identity) as GameObject;
        Bait0.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        BaitArray[0] = Bait0;
        Bait0.transform.parent = transform; //parent 설정

        GameObject Bait1 = Instantiate(HaveBait, new Vector3(-4, -0.5f, 5.2f), Quaternion.identity) as GameObject;
        Bait1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        BaitArray[1] = Bait1;
        Bait1.transform.parent = transform;

        GameObject Bait2 = Instantiate(HaveBait, new Vector3(4, -0.5f, 5.2f), Quaternion.identity) as GameObject;
        Bait2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        BaitArray[2] = Bait2;
        Bait2.transform.parent = transform;

        GameObject Bait3 = Instantiate(HaveBait, new Vector3(4.6f, -0.5f, 9.3f), Quaternion.identity) as GameObject;
        Bait3.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        BaitArray[3] = Bait3;
        Bait3.transform.parent = transform;

        GameObject Bait4 = Instantiate(HaveBait, new Vector3(-4.6f, -0.5f, 9.3f), Quaternion.identity) as GameObject;
        Bait4.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        BaitArray[4] = Bait4;
        Bait4.transform.parent = transform; 

    }

    void Update()
    {

    }

    //미끼는 최대 5개, 미끼를 프리팹으로 두고 게임오브젝트로 배열을 생성해 
    //배열번호에 맞는 프리팹이 셀렉트 화면에서 보이게. 회전은 배열번호가 0, 4면 더 회전되지 않게 하도록.
    public void OnLeftArrow()
    {
        //각도 -54*2 미만으로 안 돌아가게 / 54*2 초과로 안 돌아가게
        BaitSelectObject.transform.Rotate(0, -54, 0);
        
    }

    public void OnRightArrow()
    {
        BaitSelectObject.transform.Rotate(0, 54, 0);
        
    }
}
