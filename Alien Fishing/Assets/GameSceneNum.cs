using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneNum : MonoBehaviour
{
    [SerializeField] int gameSceneNum = 0;
    public int GetGameSceneNum() {
        return gameSceneNum;
    }
}
