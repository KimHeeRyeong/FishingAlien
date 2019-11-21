using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleton : MonoBehaviour
{
    static GameSingleton instance = null;
    public static GameSingleton Instance { get => instance; }

    public enum UIState
    {
        NONE,
        MENU,
        STORE,
        COLLECTION,
        FISHING,
        DRIVE,
        HELP,
        GET_FISH,
        TUTORIAL
    }

    float _tension = 0;
    public float tension { get => _tension; set => _tension = value; }

    string fishingEnemy = null;//낚아올린 몬스터

    Vector3 shipPos = Vector3.zero;
    Quaternion shipRot = Quaternion.identity;
    Vector3 playerPos = Vector3.zero;
    Quaternion playerRot = Quaternion.identity;

    UIState state = UIState.NONE;
    UIState preState = UIState.NONE;

    public void SetUIState(UIState changeState)
    {
        if (state == UIState.MENU|| state == UIState.HELP)
        {
            if (preState == UIState.DRIVE || preState == UIState.FISHING)
            {
                state = preState;
                preState = UIState.NONE;
                return;
            }
        }
        preState = state;
        state = changeState;
    }
    public UIState GetUIState()
    {
        return state;
    }

    int baitStartIndex = 8;
    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("destroy gamesingleton");
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);//씬이 바뀌어도 유지시킴
    }
    // Update is called once per frame
    public void SetFishingEnemy(string uid) {
        fishingEnemy = uid;
    }
    public string GetFishingEnemy()
    {
        return fishingEnemy;
    }
    public void SetShipPos(Vector3 pos, Quaternion rot) {

        Debug.Log("set Pos"+ pos);
        shipPos = pos;
        shipRot = rot;
    }
    public void SetPlayerPos(Vector3 pos, Quaternion rot)
    {
        playerPos = pos;
        playerRot = rot;
    }
    public Vector3 GetShipPos()
    {
        Debug.Log("get Pos"+ shipPos);
        return shipPos;
    }
    public Quaternion GetShipRot() {
        return shipRot;
    }
    public Vector3 GetPlayerPos()
    {
        return playerPos;
    }
    public Quaternion GetPlayerRot()
    {
        return playerRot;
    }
    public int GetBaitStartIndex() {
        return baitStartIndex;
    }
    public void SetBaitStartIndex()
    {
        baitStartIndex = Random.Range(0, 9);
    }
    void Update()
    {
    }

}
