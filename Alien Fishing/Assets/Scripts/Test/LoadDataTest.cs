using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDataTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string str = Resources.Load<TextAsset>("EnemyData/Enemy").ToString();
        List<Enemy> enemy = JsonUtility.FromJson<EnemyCollection>(str).enemy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
