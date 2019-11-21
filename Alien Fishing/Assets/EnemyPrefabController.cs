using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabController : MonoBehaviour
{
    [SerializeField]EnemyUID[] enemyUIDs;

    public GameObject ActiveUID(string enemyUID)
    {
        int cnt = enemyUIDs.Length;
        for(int i = 0; i < cnt; i++)
        {
            if (enemyUIDs[i].GetEnemyUID() == enemyUID) {
                return enemyUIDs[i].gameObject;
            }
        }
        return null;
    }
}
