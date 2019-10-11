using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraSCR : MonoBehaviour
{
    public Transform player;
    Vector3 offset;

    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public GameObject MenuPanel = null;
    public GameObject QuestPanel = null;
    public GameObject StorePanel = null;
    public GameObject BookPanel = null;

    void Start()
    {
        offset = transform.position - player.position;
        
    }

    void Update()
    {
        //패널이 열렸을 땐 움직임을 멈춰야하므로 전부 false일 때 다음 함수 실행
        if (MenuPanel.activeSelf == false && QuestPanel.activeSelf == false &&
            StorePanel.activeSelf == false && BookPanel.activeSelf == false)
        {
            transform.position = player.transform.position + offset;
            pitch -= speedV * Input.GetAxis("Mouse Y");
            yaw = player.eulerAngles.y;
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
        
    }
}
