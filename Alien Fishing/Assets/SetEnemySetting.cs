using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnemySetting : MonoBehaviour
{
    public Transform movingPoints;
    // Start is called before the first frame update
    void Awake()
    {
        int cnt = transform.childCount;
        for(int i = 0; i < cnt; i++)
        {
            transform.GetChild(i).GetComponent<BasicEnemy>().EnemyBasicSetting(movingPoints, transform.parent);
            transform.GetChild(i).GetComponent<BasicEnemy>().gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
