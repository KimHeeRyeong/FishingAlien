using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUID : MonoBehaviour
{
    [SerializeField] string enemyUID;
    public string GetEnemyUID() {
        return enemyUID;
    }
}
