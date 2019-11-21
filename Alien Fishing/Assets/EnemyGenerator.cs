using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySetting
{
    public GameObject Chunk;
    public GameObject MovingSpot;
    [HideInInspector] GameObject[] enemy;
}
public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] public EnemySetting[] enemySettings;
    public void Initialize(int index)
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
